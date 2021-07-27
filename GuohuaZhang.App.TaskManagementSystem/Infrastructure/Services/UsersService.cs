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

namespace Infrastructure.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Task<UserLoginResponseModel> Login(string email, string password)
        {
            throw new NotImplementedException();
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
