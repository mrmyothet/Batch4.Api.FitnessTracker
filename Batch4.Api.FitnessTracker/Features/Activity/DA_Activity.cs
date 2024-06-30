using Batch4.Api.FitnessTracker.Db;
using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models;
using Batch4.FitnessTracker.Models.Models.Activity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Batch4.Api.FitnessTracker.Features.Activity
{
    public class DA_Activity
    {
        private readonly AppDbContext _context;

        public DA_Activity(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActivityResponseModel> CreateActivityAsync(
            ActivityRequestModel requestActivity
        )
        {
            ActivityResponseModel response = new ActivityResponseModel();
            Tbl_Activity activity = requestActivity.ChangeActivityModel();

            try
            {
                var createdActivity = _context.Activities.Add(activity);
                int result = await _context.SaveChangesAsync();

                if (result <= 0)
                {
                    response.MessageResponse.IsSuccess = false;
                    response.MessageResponse.Message = "Creating activity is failed.";
                    return response;
                }

                Tbl_Activity tblActivity = createdActivity.Entity;
                response.MessageResponse.IsSuccess = true;
                response.MessageResponse.Message = "Creating activity is successful";

                response.ActivityId = tblActivity.ActivityId;
                response.UserId = tblActivity.UserId;
                response.ActivityTypeId = tblActivity.ActivityTypeId;
                response.Metric1 = tblActivity.Metric1;
                response.Metric2 = tblActivity.Metric2;
                response.Metric3 = tblActivity.Metric3;
                response.CaloriesBurned = tblActivity.CaloriesBurned;
            }
            catch (Exception ex)
            {
                return new ActivityResponseModel()
                {
                    MessageResponse = new MessageResponseModel(false, ex)
                };
            }

            return response;
        }

        public List<Tbl_Activity> GetActivitiesByUserId(int userId)
        {
            var lst = _context.Activities.Where<Tbl_Activity>(a => a.UserId == userId).ToList();
            return lst;
        }
    }
}
