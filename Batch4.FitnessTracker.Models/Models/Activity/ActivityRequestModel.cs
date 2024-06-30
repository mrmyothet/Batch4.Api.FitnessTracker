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
    public decimal Metric1 { get; set; }
    public decimal Metric2 { get; set; }
    public decimal Metric3 { get; set; }
}
