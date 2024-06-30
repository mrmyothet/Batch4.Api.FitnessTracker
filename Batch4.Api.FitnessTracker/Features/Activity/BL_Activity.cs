using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models.Activity;

namespace Batch4.Api.FitnessTracker.Features.Activity
{
    public class BL_Activity
    {
        private readonly DA_Activity _DA_Activity;

        public BL_Activity(DA_Activity daActivty)
        {
            _DA_Activity = daActivty;
        }

        public async Task<ActivityResponseModel> CreateActivityAsync(ActivityRequestModel activity)
        {
            ActivityResponseModel response = await _DA_Activity.CreateActivityAsync(activity);

            return response;
        }

        public List<Tbl_Activity> GetActivitiesByUserId(int userId)
        {
            return _DA_Activity.GetActivitiesByUserId(userId);
        }
    }
}
