using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Models.User
{
    public class LoginResponseModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public MessageResponseModel? messageResponse { get; set; }
    }
}
