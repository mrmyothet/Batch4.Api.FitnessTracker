using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models;
using Batch4.FitnessTracker.Models.Models.ActivityType;

namespace Batch4.Api.FitnessTracker.Features.ActivityType;

public class BL_ActivityType
{
    private readonly DA_ActivityType _DA_ActivityType;

    public BL_ActivityType(DA_ActivityType DA_ActivityType)
    {
        _DA_ActivityType = DA_ActivityType;
    }

    public ActivityTypeListResponseModel GetActivityTypeList()
    {
        ActivityTypeListResponseModel response = new ActivityTypeListResponseModel();

        var lst = _DA_ActivityType.GetActivityTypes();
        if (lst.Count <= 0)
        {
            response.MessageResponse.IsSuccess = false;
            response.MessageResponse.Message = "No data found.";
            return response;
        }

        response.MessageResponse.IsSuccess = true;
        response.MessageResponse.Message = "";
        response.ActivityTypeList = lst;
        return response;
    }

    public ActivityTypeResponseModel CreateActivityType(string activityTypeName)
    {
        ActivityTypeResponseModel response = new ActivityTypeResponseModel();

        var item = _DA_ActivityType.CreateActivityType(activityTypeName);
        if (item is null)
        {
            response.MessageResponse.IsSuccess = false;
            response.MessageResponse.Message = "Creating Activity Type is failed.";
            return response;
        }

        response.MessageResponse.IsSuccess = true;
        response.MessageResponse.Message = "Creating Activity Type is successful.";
        response.ActivityType = item;
        return response;
    }
}
