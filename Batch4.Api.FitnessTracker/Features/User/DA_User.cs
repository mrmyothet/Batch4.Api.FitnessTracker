using System.Diagnostics;
using Batch4.Api.FitnessTracker.Db;
using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models;
using Batch4.FitnessTracker.Models.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Batch4.Api.FitnessTracker.Features.User
{
    public class DA_User
    {
        private readonly AppDbContext _context;

        public DA_User(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MessageResponseModel> RegisterAsync(Tbl_User tbl_user)
        {
            MessageResponseModel response = new MessageResponseModel();
            try
            {
                await _context.tblUser.AddAsync(tbl_user);
                int result = await _context.SaveChangesAsync();
                response =
                    result > 0
                        ? new MessageResponseModel(true, "Registration successful!")
                        : new MessageResponseModel(false, "Registration Fail!");
            }
            catch (Exception ex)
            {
                response = new MessageResponseModel(false, ex);
            }
            return response;
        }

        public async Task<LoginResponseModel> LoginAsync(Tbl_User tbl_User)
        {
            LoginResponseModel response = new LoginResponseModel();
            try
            {
                var item = await _context
                    .tblUser.AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.UserName == tbl_User.UserName && x.Password == tbl_User.Password
                    );
                if (item is null)
                {
                    response.messageResponse = new MessageResponseModel(false, "User not found");
                    return response;
                }
                response.UserId = item.UserId;
                response.UserName = item.UserName;
                response.messageResponse = new MessageResponseModel(true, "Successfully Login");
            }
            catch (Exception ex)
            {
                response.messageResponse = new MessageResponseModel(false, ex);
            }
            return response;
        }

        public async Task<CalorieGoalResponseModel> SetCalorieGoal(CalorieGoalModel model)
        {
            CalorieGoalResponseModel response = new CalorieGoalResponseModel();

            try
            {
                var user = await _context.tblUser.FirstOrDefaultAsync(u =>
                    u.UserId == model.UserId
                );

                if (user is null)
                {
                    string message = "No user found.";
                    response.messageResponse = new MessageResponseModel(false, message);
                    return response;
                }

                user.CalorieGoal = model.CalorieGoal;
                int result = await _context.SaveChangesAsync();

                if (result <= 0)
                {
                    string message = "Update failed to Tbl_User";
                    response.messageResponse = new MessageResponseModel(false, message);
                    return response;
                }

                response.calorieGoal = model;
                response.messageResponse = new MessageResponseModel(
                    true,
                    "Set Calorie Goal is Successful."
                );
            }
            catch (Exception ex)
            {
                response.messageResponse = new MessageResponseModel(false, ex);
                return response;
            }

            return response;
        }
    }
}
