using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Db;

[Table("Tbl_ActivityType")]
public class Tbl_ActivityType
{
    [Key]
    public int ActivityTypeId { get; set; }
    public string ActivityTypeName { get; set; }
}
