using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Models.Activity;

public class ActivityResponseModel
{
    public int ActivityId { get; set; }
    public int UserId { get; set; }
    public int ActivityTypeId { get; set; }
    public decimal Metric1 { get; set; }
    public decimal Metric2 { get; set; }
    public decimal Metric3 { get; set; }
    public decimal CaloriesBurned { get; set; }
    public MessageResponseModel MessageResponse { get; set; }

    public ActivityResponseModel()
    {
        MessageResponse = new MessageResponseModel();
    }
}
