using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_Account
    {
        DAL_Account DAL_method = new DAL_Account();

        public IEnumerable<Account_Data> retrieve_all_user_data()
        {
            DAL_method.init_client();
            IEnumerable<Account_Data> accounts = DAL_method.retrieve_all_user_data();
            return accounts;
        }

        public Account_Data retrieve_user_data(string id)
        {
            DAL_method.init_client();
            Account_Data account = DAL_method.retrieve_user_data(id);
            return account;
        }

        public bool Create_new_account(Account_Data account)
        {
            DAL_method.init_client();
            return DAL_method.insert_data_to_table(account).Result;
        }

        public bool Update_account(Account_Data account)
        {
            DAL_method.init_client();
            return DAL_method.update_data_to_table(account).Result;
        }

        public void Update_all_account(IEnumerable<Account_Data> accounts)
        {
            DAL_method.init_client();
            foreach (Account_Data account in accounts)
            {
                DAL_method.update_data_to_table(account);
            }
            

        }

        public void Delete_specific_account(string id)
        {
            DAL_method.init_client();
            DAL_method.delete_from_table(id);
        }
    }
}
