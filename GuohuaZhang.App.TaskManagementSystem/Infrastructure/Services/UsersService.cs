using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Net;
/*using AutoMapper;*/

namespace Infrastructure.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICurrentUser _currentUser;
        private readonly ITasksHistoryService _tasksHistoryService;
        private readonly ITasksService _tasksService;

        public UsersService(IUsersRepository usersRepository, ICurrentUser currentUser,
            ITasksHistoryService tasksHistoryService,
            ITasksService tasksService)
        {
            _usersRepository = usersRepository;
            _currentUser = currentUser;
            _tasksHistoryService = tasksHistoryService;
            _tasksService = tasksService;
        }

        public async Task ConfirmFinished(TasksResponseModel tasksResponse)
        {
           if(_currentUser.UserId != tasksResponse.userid)
                throw new HttpException(HttpStatusCode.Unauthorized, "You are not Authorized to finish this Task");

            var taskHistory = new TaskHistoryRequestModel
            {
                TaskId = tasksResponse.Id,
                UserId = tasksResponse.userid,
                Title = tasksResponse.Title,
                Description = tasksResponse.Description,
                DueDate = tasksResponse.DueDate,
                Remarks = tasksResponse.Remarks,
            };
            await _tasksHistoryService.AddTaskHistory(taskHistory);
            await _tasksService.DeleteTask(tasksResponse.Id, tasksResponse.userid);
        }

        public async Task<UserRegisterResponseModel> GetUser(string email)
        {
           var user = await _usersRepository.GetUserByEmail(email);
            if (user == null) throw new NotFoundException("there is no such user account");
            var response = new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Fullname = user.Fullname,
                Mobileno = user.Mobileno
            };

            return response;
        }

        public async Task<List<UserRegisterResponseModel>> GetUser()
        {
            var users = await _usersRepository.ListAllAsync();

            var usermodels = new List<UserRegisterResponseModel>();
            foreach(var user in users)
            {
                usermodels.Add(new UserRegisterResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Fullname = user.Fullname,
                    Mobileno = user.Mobileno
                });
            }
            return usermodels;
        }

        public async Task<UserRegisterResponseModel> GetUserById(int id)
        {
            var user = await _usersRepository.GetByIdAsync(id);
            if (user == null) throw new NotFoundException("User", id);
            var response =new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Fullname = user.Fullname,
                Mobileno = user.Mobileno
            };

            return response;

        }

        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            var dbUser = await _usersRepository.GetUserByEmail(email);
            if (dbUser == null)
            {
                throw new NotFoundException("Email does not exists, Please register first");
            }
            var hashedPassword = HashPassword(password, dbUser.Salt);
            if (hashedPassword == dbUser.HashedPassword)
            {
                //correct password
                var userLoginResponse = new UserLoginResponseModel
                {
                    Id = dbUser.Id,
                    Email = dbUser.Email,
                    FullName = dbUser.Fullname,
                    Mobileno = dbUser.Mobileno,
                    
                };
                return userLoginResponse;
            }
            return null;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel)
        {
            //make sure email dose not exist in database(User table)
            var dbUser = await _usersRepository.GetUserByEmail(requestModel.Email);
            if (dbUser != null)//we already have user with same email
            {
                
                throw new ConflictException("Email Already Exists");
            }
            
            var salt = CreateSalt();//create a unique salt, using Microsoft.AspNetCore.Cryptography.KeyDerivation;
            var hashedPassword = HashPassword(requestModel.Password, salt);
            //save to db
            var user = new Users
            {
                Email = requestModel.Email,
                Salt = salt,
                Fullname = requestModel.Fullname,
                Mobileno = requestModel.Mobileno,
                HashedPassword = hashedPassword
            };
            //save to db by calling UserRepository add method
            var createUser = await _usersRepository.AddAsync(user);
            var userResponse = new UserRegisterResponseModel
            {
                Id = createUser.Id,
                Email = createUser.Email,
                Fullname = createUser.Fullname,
                Mobileno = createUser.Mobileno
            };
            return userResponse;


        }

        public async Task UpdateUser(UserRegisterRequestModel model)
        {
            var user = await _usersRepository.GetUserByEmail(model.Email);
            if (_currentUser.UserId != user.Id)
                throw new HttpException(HttpStatusCode.Unauthorized, "You are not Authorized to Review");
            var newsalt = CreateSalt();
            var hashpassword = HashPassword(model.Email, newsalt);

            var newUser = new Users
            {
                Id = user.Id,
                Email = user.Email,
                HashedPassword = hashpassword,
                Salt = newsalt,
                Fullname = model.Fullname,
                Mobileno = model.Mobileno

            };
            await _usersRepository.UpdateAsync(newUser);
    }

        //never write security by you own
        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }
        private string HashPassword(string password, string salt)
        {
            //Aarogon
            //Pbkdf2
            //BCrypt
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                    password: password,
                                                                    salt: Convert.FromBase64String(salt),
                                                                    prf: KeyDerivationPrf.HMACSHA512,
                                                                    iterationCount: 10000,
                                                                    numBytesRequested: 256 / 8));
            return hashed;
        }



    }
}
