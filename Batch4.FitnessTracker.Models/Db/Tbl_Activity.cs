using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Db
{
    [Table("Tbl_Activity")]
    public class Tbl_Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public int ActivityTypeId { get; set; }
        public double Metric1 { get; set; }
        public double Metric2 { get; set; }
        public double Metric3 { get; set; }
        public double CaloriesBurned { get; set; }
    }
}
