using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;
using System.Windows.Controls;

namespace BUS_QuanLy
{
    public class User_Control_BUS
    {
        User_Control_DAL data = new User_Control_DAL();

        public User_Control_BUS()
        {
        }



        public User Get_Single_UserInfo()
        {
            return data.Return_Single_User();
        }
    }

}
