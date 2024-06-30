using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models;
using Batch4.FitnessTracker.Models.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.FitnessTracker.Features.User
{
    public class BL_User
    {
        private readonly DA_User _da_user;

        public BL_User(DA_User da_user)
        {
            _da_user = da_user;
        }

        public async Task<MessageResponseModel> RegisterAsync(RegisterModel requestModel)
        {
            var checkRegisterResponse = checkRegisterNullValue(requestModel);
            if (checkRegisterResponse is not null) return checkRegisterResponse;
            var response = await _da_user.RegisterAsync(requestModel.Change());
            return response;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginModel loginModel)
        {
            LoginResponseModel response = new LoginResponseModel();
            var checkLoginResponse = checkLoginNullValue(loginModel);
            if(checkLoginResponse is not null)
            {
                response.messageResponse = checkLoginResponse;
                return response;
            }
            response=await _da_user.LoginAsync(loginModel.Change());
            return response;
        }

        private MessageResponseModel checkRegisterNullValue(RegisterModel registerModel)
        {
            if (registerModel is null)
            {
                return new MessageResponseModel(false, "RegisterModel is null");
            }
            if (string.IsNullOrWhiteSpace(registerModel.UserName))
            {
                return new MessageResponseModel(false, "User name is null");
            }
            if (string.IsNullOrWhiteSpace(registerModel.Password) || registerModel.Password.Length < 8)
            {
                return new MessageResponseModel(false, "Password must be 8 character long");
            }
            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                return new MessageResponseModel(false, "Password and ConfirmPassword Should be same");
            }
            return null;
        }

        private MessageResponseModel checkLoginNullValue(LoginModel loginModel)
        {
            if (loginModel is null)
            {
                return new MessageResponseModel(false, "loginModel is null");
            }
            if (string.IsNullOrWhiteSpace(loginModel.UserName))
            {
                return new MessageResponseModel(false, "Please type UserName");
            }
            if (string.IsNullOrWhiteSpace(loginModel.Password))
            {
                return new MessageResponseModel(false, "Please type Password");
            }
            return null;
        }
    }
}
