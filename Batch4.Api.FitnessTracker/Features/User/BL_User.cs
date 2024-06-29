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
            var checkResponse = checkRegisterNullValue(requestModel);
            if (checkResponse is not null) return checkResponse;
            var response = await _da_user.RegisterAsync(requestModel.Change());
            return response;
        }

        private MessageResponseModel checkRegisterNullValue(RegisterModel requestModel)
        {
            if (requestModel == null)
            {
                return new MessageResponseModel(false, "RegisterModel is null");
            }
            if (string.IsNullOrWhiteSpace(requestModel.UserName))
            {
                return new MessageResponseModel(false, "User name is null");
            }
            if (string.IsNullOrWhiteSpace(requestModel.Password)||requestModel.Password.Length<8  )
            {
                return new MessageResponseModel(false, "Password must be 8 character long");
            }
            if (requestModel.Password != requestModel.ConfirmPassword)
            {
                return new MessageResponseModel(false, "Password and ConfirmPassword Should be same");
            }
            return null;
        }
    }
}
