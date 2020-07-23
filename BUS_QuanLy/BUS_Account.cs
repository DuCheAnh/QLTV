using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public static class BUS_Account
    {
        static DAL_Account DAL_method = new DAL_Account();

        public static IEnumerable<Account_Data> retrieve_all_user_data()
        {
            DAL_method.init_client();
            IEnumerable<Account_Data> accounts = DAL_method.retrieve_all_user();
            return accounts;
        }

        public static Account_Data retrieve_user_data(string id)
        {
            DAL_method.init_client();
            Account_Data account = DAL_method.retrieve_user_data(id);
            return account;
        }

        public static bool Create_new_account(UserRegister account)
        {
            DAL_method.init_client();
            return DAL_method.create_new_user(account.Username, account.Password, account.Email);
        }

        public static bool Update_account(Account_Data account)
        {
            DAL_method.init_client();
            if (DAL_method.update_user_data(account))
                return false;
            return true;

        }

        public static void Update_all_account(IEnumerable<Account_Data> accounts)
        {
            DAL_method.init_client();
            foreach (Account_Data account in accounts)
            {
                DAL_method.update_user_email(account.UID, account.email);
                DAL_method.update_user_password(account.UID, account.password);
            }
            

        }

        public static void Update_Account_Email(string uID, string newEmail)
        {
            DAL_method.update_user_email(uID, newEmail);
        }

        public static void Delete_specific_account(string id)
        {
            DAL_method.init_client();
            DAL_method.delete_user(id);
        }

        public static void Update_account_Password(string uID, string newPassword)
        {
            DAL_method.update_user_password(uID, newPassword);
        }

        public static bool Check_account_oldPassword(string uID, string oldPassword)
        {
            Account_Data account = DAL_method.retrieve_user_data(uID);

            if (oldPassword == account.password)
            {
                return true;
            }

            return false;
        }
    }
}
