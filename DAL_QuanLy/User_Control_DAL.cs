using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class User_Control_DAL
    {
        public User_Control_DAL()
        {
        }


        public User Return_Single_User()
        {
            User singleUser = new User() { ID = 1, Name = "cuong", Email = "tranhdayken@gmail.com", PhoneNumber = "0355766760", Address = "hcm", DOB = new DateTime(2000, 2, 28), Gender = true };
            return singleUser;
        }
    }
}
