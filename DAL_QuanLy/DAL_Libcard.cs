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
    class DAL_Libcard : DB_connect
    {
        #region variables
        //variables
        public IFirebaseClient client;
        string sLibCardTable_path = "LibCards/";
        #endregion
        //Connect to the database, run this before all the funcs below
        public void init_client()
        {
            client = new FireSharp.FirebaseClient(config);
        }
        #region using values
        //insert values into table, string by string
        public async void insert_values_to_table(
                    string sLCID, string sPIN, string sAccountType, string sIdentityCard
                    , string sName, DateTime dDOB, bool bGender, DateTime dExpired)
        {
            var data = new LibCard_Data(sLCID,sPIN,sAccountType,sIdentityCard,sName,dDOB,bGender,dExpired);
            SetResponse response = await client.SetTaskAsync(sLibCardTable_path + sLCID, data);
            LibCard_Data result = response.ResultAs<LibCard_Data>();

        }

        //update values into table, string by string
        public async void update_values_to_table(
                    string sLCID, string sPIN, string sAccountType, string sIdentityCard
                    , string sName, DateTime dDOB, bool bGender, DateTime dExpired)
        {
            var data = new LibCard_Data(sLCID, sPIN, sAccountType, sIdentityCard, sName, dDOB, bGender, dExpired);
            FirebaseResponse response = await client.UpdateTaskAsync(sLibCardTable_path + sLCID, data);
            LibCard_Data result = response.ResultAs<LibCard_Data>();
        }

        #endregion
        #region using LibCard_Data
        // Insert LibCard_Data to table
        public async void insert_data_to_table(LibCard_Data data)
        {
            SetResponse response = await client.SetTaskAsync(sLibCardTable_path + data.LCID, data);
            LibCard_Data result = response.ResultAs<LibCard_Data>();
        }

        //Delete data from table by UID
        public async void delete_from_table(string sLCID)
        {
                FirebaseResponse delete_response = await client.DeleteTaskAsync(sLibCardTable_path + sLCID);           
        }

        // update LibCard_Data to table
        public async void update_data_to_table(LibCard_Data data)
        {
            FirebaseResponse response = await client.UpdateTaskAsync(sLibCardTable_path + data.LCID, data);
            LibCard_Data result = response.ResultAs<LibCard_Data>();
        }

        //retrieve LibCard_Data from table by UID
        public LibCard_Data retrieve_user_data(string sLCID)
        {
            var retrieve_response = client.Get(sLibCardTable_path + sLCID);
            LibCard_Data data = retrieve_response.ResultAs<LibCard_Data>();
            return data;
        }
        #endregion
    }
}
