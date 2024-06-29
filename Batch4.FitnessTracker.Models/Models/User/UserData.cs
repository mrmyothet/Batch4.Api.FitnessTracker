
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.FitnessTracker.Models.Models.User
{
    public class UserData
    {
        private string userName;
        private string password;
        private int calorieGoal;
        private int loginAttemps = 0;

        public UserData(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            this.calorieGoal = 0;
        }

        public UserData()
        {

        }

        public void SetCalorieGoal(int goal)
        {
            if(goal<0)
            {
                throw new ArgumentException("goal cannot be negative value");
            }
            calorieGoal= goal;
        }

        public int GetCalorieGoal()
        {
            return calorieGoal;
        }

        public string GetUserName()
        {
            return userName;
        }

        public string GetPassword()
        {
            return password;
        }

        public bool CheckLoginAttemps()
        {
            return loginAttemps < 3;
        }

        public void RestLoginAttemps()
        {
            loginAttemps = 0;
        }

        public void IncreaserLoginAttemps()
        {
            loginAttemps++;
        }

    }
}
