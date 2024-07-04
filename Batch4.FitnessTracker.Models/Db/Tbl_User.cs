using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Db
{
    [Table("Tbl_User")]
    public class Tbl_User
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int CalorieGoal { get; set; }
        public decimal TotalCaloriesBurned { get; set; }
    }
}
