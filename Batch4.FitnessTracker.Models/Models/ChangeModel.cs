
using Batch4.FitnessTracker.Models.Db;
using Batch4.FitnessTracker.Models.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Models
{
    public static class ChangeModel
    {
        public static Tbl_User Change(this RegisterModel registerModel)
        {
            Tbl_User tbl_User = new Tbl_User
            {
                UserName = registerModel.UserName,
                Password = registerModel.Password
            };
            return tbl_User;
        }

        public static Tbl_User Change(this LoginModel loginModel)
        {
            Tbl_User tbl_User = new Tbl_User
            {
                UserName = loginModel.UserName,
                Password = loginModel.Password
            };
            return tbl_User;
        }
    }
}
