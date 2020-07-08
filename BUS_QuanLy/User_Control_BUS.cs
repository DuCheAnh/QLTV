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
        DAL_Account UserData = new DAL_Account();

        public User_Control_BUS()
        {
        }

        public Account_Data Get_Single_UserInfo(string sUID)
        {
            UserData.init_client();
            return UserData.retrieve_user_data(sUID);
        }
        /// <summary>
        /// Get users password by UID (UID must exist)
        /// </summary>
        /// <param name="sUID"></param>
        /// <returns></returns>
        public string get_user_password(string sUID)
        {
            return UserData.retrieve_user_data(sUID).password;
        }

        public bool Checking(string UID, string OldPassword)
        {
            UserData.init_client();
            Account_Data data =  UserData.retrieve_user_data(UID);
            if (data.password == OldPassword)
                return true;
            return false;
        }

        public void change_user_Email(string currentUID, string newEmail)
        {
            UserData.init_client();
            UserData.update_user_email(currentUID, newEmail);
        }

        /// <summary>
        /// Get account password for signing in by user account
        /// <list type="bullet">
        /// <item>If user account doesn't exist return null</item>
        /// </list>
        /// </summary>
        /// <param name="sAccount"></param>
        /// <returns></returns>
        public string get_account_password(string sAccount)
        {
            UserData.init_client();
            if (UserData.search_for_account(sAccount) != null)
            {
                return UserData.search_for_account(sAccount).password;
            }
            else return null;
        }


        public Account_Data search_for_account(string sAccount)
        {
            UserData.init_client();

            return UserData.search_for_account(sAccount);
        }

        /// <summary>
        /// change users password to a new one, return true if succeeded, false if not
        /// </summary>
        /// <param name="sUID"></param>
        /// <param name="sNewPassword"></param>
        /// <returns></returns>
        public bool change_user_password(string sUID,string sNewPassword)
        {
            UserData.init_client();

            return UserData.update_user_password(sUID, sNewPassword);
        }
    }

}
