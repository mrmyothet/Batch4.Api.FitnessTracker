using Batch4.Api.FitnessTracker.Db;
using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models;
using Batch4.FitnessTracker.Models.Models.Activity;

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
                _context.Activities.Add(activity);
                int result = await _context.SaveChangesAsync();
                response.MessageResponse =
                    result > 0
                        ? new MessageResponseModel(true, "Creating activity is successful")
                        : new MessageResponseModel(false, "Creating activity is failed.");
            }
            catch (Exception)
            {
                throw;
            }

            return response;
        }
    }
}
