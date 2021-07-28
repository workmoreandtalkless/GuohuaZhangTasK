using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUsersService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel);
        Task<UserLoginResponseModel> Login(string email, string password);
        Task<UserRegisterResponseModel> GetUserById(int id);
        Task<UserRegisterResponseModel> GetUser(string email);
        Task<List<UserRegisterResponseModel>> GetUser();
        Task UpdateUser(UserRegisterRequestModel model);

        Task ConfirmFinished(TasksResponseModel tasksResponse);
        
    }
}
