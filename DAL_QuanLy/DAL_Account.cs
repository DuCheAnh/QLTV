using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Response;
using FireSharp.Config;
using FireSharp.Interfaces;
using DTO_QuanLy;
namespace DAL_QuanLy
{
    public class DAL_Account : DB_connect
    {
        #region variables
        //variables
        public IFirebaseClient client;
        string sAccountTable_path = "LibAccounts/";
        #endregion
        //Connect to the database, run this before all the funcs below
        public void init_client()
        {
            client = new FireSharp.FirebaseClient(config);
        }
        #region using values
        //insert values into table, string by string

        public async void insert_values_to_table(
                    string sUID, string sAccount, string sPassword, 
                    string sProfilePicture, string sName, DateTime sDOB, bool bGender, string sEmail,
                    string sIdentity, string sAccountType)
        {
            var data = new Account_Data(sUID, sAccount, sPassword, sProfilePicture,
                                       sName, sDOB, bGender, sEmail, sIdentity, sAccountType);
                SetResponse response = await client.SetTaskAsync(sAccountTable_path + sUID, data);
                Account_Data result = response.ResultAs<Account_Data>();
            
        }

        //update values into table, string by string
        public async void update_values_to_table(string sUID, string sAccount, string sPassword,
                   string sProfilePicture, string sName, DateTime sDOB, bool bGender, string sEmail,
                   string sIdentity, string sAccountType)
        {
            var data = new Account_Data(sUID, sAccount, sPassword, sProfilePicture,
                                       sName, sDOB, bGender, sEmail, sIdentity, sAccountType);
            FirebaseResponse response = await client.UpdateTaskAsync(sAccountTable_path + sUID, data);
            Account_Data result = response.ResultAs<Account_Data>();
        }

        #endregion
        #region using Account_data
        // Insert Account_data to table
        public async void insert_data_to_table(Account_Data data)
        {
            SetResponse response = await client.SetTaskAsync(sAccountTable_path + data.UID, data);
            Account_Data result = response.ResultAs<Account_Data>();
        }

        //Delete data from table by UID
        public async void delete_from_table(string sUID)
        {           
                FirebaseResponse delete_response = await client.DeleteTaskAsync(sAccountTable_path + sUID);            
        }

        // update Account_data to table
        public async void update_data_to_table(Account_Data data)
        {
            FirebaseResponse response = await client.UpdateTaskAsync(sAccountTable_path + data.UID, data);
            Account_Data result = response.ResultAs<Account_Data>();
        }

        //retrieve Account_data from table by UID
        public Account_Data retrieve_user_data(string sUID)
        {
            Account_Data data = new Account_Data("1", "trdayken", "123", "none", "cuong", new DateTime(2000, 2, 28), true, "trdayken@gmail.com", "identity?", "im VIP Baby!!!");
/*            var retrieve_response = client.Get(sAccountTable_path + sUID);
            Account_Data data = retrieve_response.ResultAs<Account_Data>();*/
            return data;
        }
        #endregion

        public List<Account_Data> retrieve_all_user_data()
        {
            List<Account_Data> data = new List<Account_Data>();

            data.Add(new Account_Data("1", "trdayken", "123", "none", "cuong", new DateTime(2000, 2, 28), true, "trdayken@gmail.com", "identity?", "im VIP Baby!!!"));

            return data;
        }
    }
}
