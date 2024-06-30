using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Batch4.FitnessTracker.Models.Db;

namespace Batch4.FitnessTracker.Models.Models.ActivityType;

public class ActivityTypeListResponseModel
{
    public ActivityTypeListResponseModel()
    {
        MessageResponse = new MessageResponseModel();
    }

    public List<Tbl_ActivityType> ActivityTypeList { get; set; }

    public MessageResponseModel MessageResponse { get; set; }
}
