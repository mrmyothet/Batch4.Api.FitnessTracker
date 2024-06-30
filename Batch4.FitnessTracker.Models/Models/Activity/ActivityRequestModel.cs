using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Models.Activity;

public class ActivityRequestModel
{
    public int UserId { get; set; }
    public int ActivityTypeId { get; set; }
    public double Metric1 { get; set; }
    public double Metric2 { get; set; }
    public double Metric3 { get; set; }
}
