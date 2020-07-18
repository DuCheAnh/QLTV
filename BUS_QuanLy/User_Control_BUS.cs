using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;
using System.Windows;
using System.Windows.Controls;

namespace BUS_QuanLy
{
    public class User_Control_BUS
    {

        DAL_Account Data = new DAL_Account();
        List<Account_Data> possible_account = new List<Account_Data>();
        public User_Control_BUS()
        {
        }

        public Account_Data Get_Single_UserInfo(string sUID)
        {
            Data.init_client();
            return Data.retrieve_user_data(sUID);
        }

        public bool LoginUser(string username, string Password)
        {
            Data.init_client();
            possible_account = Data.retrieve_all_user();

            foreach (Account_Data account in possible_account)
            {
                if (account.account == username && account.password == Password)
                    return true;
            }

            return false;
        }
        public bool RegisterIn(string Account, string Password, string Email)
        {
            Data.init_client();
            possible_account = Data.retrieve_all_user();
           
            
                if (Data.search_for_username(Account) == null)
                {

                    return Data.Create_new_user(Account, Password, Email);
                }
                
            
            return false;
        }
    }
}

        
    
   


