using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Batch4.FitnessTracker.Models.Db;

namespace Batch4.FitnessTracker.Models.Models.ActivityType;

public class ActivityTypeResponseModel
{
    public Tbl_ActivityType ActivityType { get; set; }

    public MessageResponseModel MessageResponse { get; set; }

    public ActivityTypeResponseModel()
    {
        MessageResponse = new MessageResponseModel();
    }
}
