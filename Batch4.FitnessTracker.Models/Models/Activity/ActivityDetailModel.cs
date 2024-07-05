using Batch4.FitnessTracker.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Models.Activity
{
    public class ActivityDetailModel
    {
        public UserResponseModel? userResponse { get; set; }
        public ActivityDetail? activityDetail { get; set; }
    }

    public class ActivityDetail
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int ActivityTypeId { get; set; }
        public string? ActivityTypeName { get; set; }
        public decimal Metric1 { get; set; }
        public decimal Metric2 { get; set; }
        public decimal Metric3 { get; set; }
        public decimal CaloriesBurned { get; set; }
    }
}
