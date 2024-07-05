
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Models.User
{
    public class UserResponseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CalorieGoal { get; set; }
        public decimal TotalCaloriesBurned { get; set; }
    }
}
