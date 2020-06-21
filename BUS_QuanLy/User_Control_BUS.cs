using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;
using System.Windows;

namespace BUS_QuanLy
{
    public class User_Control_BUS
    {
        DAL_Account Data= new DAL_Account();

        public User_Control_BUS()
        {
        }

        public Account_Data Get_Single_UserInfo(string sUID)
        {
            Data.init_client();
            return Data.retrieve_user_data(sUID);
        }
    }

}
