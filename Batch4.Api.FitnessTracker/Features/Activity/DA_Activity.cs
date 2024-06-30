using Batch4.Api.FitnessTracker.Db;
using Batch4.Api.FitnessTracker.Features.ActivityType;
using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models;
using Batch4.FitnessTracker.Models.Models.Activity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Batch4.Api.FitnessTracker.Features.Activity
{
    public class DA_Activity
    {
        private readonly AppDbContext _context;
        private readonly DA_ActivityType _DA_ActivityType;

        public DA_Activity(AppDbContext context, DA_ActivityType dA_ActivityType)
        {
            _context = context;
            _DA_ActivityType = dA_ActivityType;
        }

        public async Task<ActivityResponseModel> CreateActivityAsync(
            ActivityRequestModel requestActivity
        )
        {
            ActivityResponseModel response = new ActivityResponseModel();
            Tbl_Activity activity = requestActivity.ChangeActivityModel();

            try
            {
                activity.CaloriesBurned = await CalculateCaloriesBurnedAsync(requestActivity);

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

        public async Task<Tbl_Activity> UpdateActivityAsync(
            int activityId,
            ActivityRequestModel request
        )
        {
            var item = await _context.Activities.FirstOrDefaultAsync(x =>
                x.ActivityId == activityId
            );

            if (item is null)
                return item;

            item.ActivityTypeId = request.ActivityTypeId;
            item.Metric1 = request.Metric1;
            item.Metric2 = request.Metric2;
            item.Metric3 = request.Metric3;
            item.CaloriesBurned = await CalculateCaloriesBurnedAsync(request);

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<decimal> CalculateCaloriesBurnedAsync(ActivityRequestModel request)
        {
            decimal totalCaloriesBurned = 0;

            int activityTypeId = request.ActivityTypeId;
            var tblActivityType = await _DA_ActivityType.GetActivityTypeByIdAsyn(activityTypeId);
            if (tblActivityType.ActivityTypeId == -1)
                totalCaloriesBurned = -1;

            switch (tblActivityType.ActivityTypeName)
            {
                case "Walking":
                    totalCaloriesBurned = request.Metric1 * (decimal)0.035;
                    break;

                case "Swimming":
                    totalCaloriesBurned = request.Metric2 * 8;
                    break;

                default:
                    totalCaloriesBurned = -1;
                    break;
            }

            return totalCaloriesBurned;
        }

        public async Task<int> DeleteActivityAsync(int activityId)
        {
            var item = await _context.Activities.FirstOrDefaultAsync(x =>
                x.ActivityId == activityId
            );
            if (item is null)
                return 0;

            _context.Activities.Remove(item);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
