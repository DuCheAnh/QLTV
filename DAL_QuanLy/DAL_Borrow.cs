using DTO_QuanLy;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;

namespace DAL_QuanLy
{
    public class DAL_Borrow : DB_connect
    {
        #region variables
        //variables
        public IFirebaseClient client;
        string sBorrowTable_path = "Borrows/";
        #endregion
        //Connect to the database, run this before all the funcs below
        public void init_client()
        {
            client = new FireSharp.FirebaseClient(config);
        }


        #region function

        #region generate BID
        private string create_new_id()
        {
            var retrieve_response = client.Get(sBorrowTable_path + "count");
            Borrow_Count data = retrieve_response.ResultAs<Borrow_Count>();
            int plus = Convert.ToInt32(data.value) + 1;
            data.value = plus.ToString();
            SetResponse response = client.Set(sBorrowTable_path + "count", data);
            return plus.ToString();
        }
        #endregion


        /// <summary>
        /// Add new borrow info to the database with BID, and UID
        /// </summary>
        /// <param name="sBID"></param>
        /// <param name="sUID"></param>
        /// <returns></returns>
        public bool add_new_borrow(string sBID, string sUID, DateTime dtBorrowDate, int returnafter)
        {
            try
            {
                //setups
                var data = new Borrow_Data(sBID, sUID, dtBorrowDate, returnafter);
                DAL_Account account = new DAL_Account();
                DAL_Book book = new DAL_Book();
                book.init_client();
                account.init_client();
                data.BrID = create_new_id();
                //minus 1 book from the database
                Book_Data bookdata = book.retrieve_book_data(sBID);
                bookdata.left -= 1;
                book.update_book_data(bookdata);
                //update user brid
                account.add_brid(sUID, data.BrID);
                //add new borrow info
                SetResponse response = client.Set(sBorrowTable_path + data.BrID, data);
                Borrow_Data result = response.ResultAs<Borrow_Data>();
                if (result != null) return true;
            }
            catch (Exception)
            {

            }
            return false;
        }


        /// <summary>
        /// Delete borrow info specified by sBrID
        /// </summary>
        /// <param name="sBrID"></param>
        /// <returns></returns>
        public bool delete_borrow(string sBrID)
        {
            try
            {
                FirebaseResponse delete_response = client.Delete(sBorrowTable_path + sBrID);
                if (delete_response != null) return true;
            }
            catch (Exception) { }
            return false;
        }


        /// <summary>
        /// retrieve specific borrow data by sBrID
        /// </summary>
        /// <param name="sBrID"></param>
        /// <returns></returns>
        public Borrow_Data retrieve_borrow_data(string sBrID)
        {
            var retrieve_response = client.Get(sBorrowTable_path + sBrID);
            if (retrieve_response.Body != "null")
            {
                Borrow_Data data = retrieve_response.ResultAs<Borrow_Data>();
                return data;
            }
            return null;
        }




        /// <summary>
        /// Retrieve all borrows info then store them to a list
        /// </summary>
        /// <returns></returns>
        public List<Borrow_Data> retrieve_all_borrows()
        {
            //create a list to store data
            List<Borrow_Data> borrow_list = new List<Borrow_Data>();
            //get all the data, then transfer them to a dictionnary variable
            FirebaseResponse response = client.Get(sBorrowTable_path);
            Dictionary<string, Borrow_Data> all_data = new Dictionary<string, Borrow_Data>();
            if (response.Body != "null")
                all_data = response.ResultAs<Dictionary<string, Borrow_Data>>();


            foreach (var user in all_data)
            {
                borrow_list.Add(user.Value);
            }
            return borrow_list;
        }


        public bool update_packed_to(bool bBool, Borrow_Data brData)
        {
            brData.packed = true;
            FirebaseResponse update_response = client.Update(sBorrowTable_path + brData.BrID, brData);
            if (update_response != null) return true;
            else return false;
        }
        public bool update_returned_to(bool bBool, Borrow_Data brData)
        {
            brData.returned = true;
            FirebaseResponse update_response = client.Update(sBorrowTable_path + brData.BrID, brData);
            if (update_response != null) return true;
            else return false;
        }
        /// <summary>
        /// Search for a specific sUID then return all new found Borrow data to a list
        /// </summary>
        /// <param name="sUID"></param>
        /// <returns></returns>
        public List<Borrow_Data> search_for_UID(string sUID)
        {
            List<Borrow_Data> list = new List<Borrow_Data>();
            foreach (Borrow_Data user in retrieve_all_borrows())
            {
                if (sUID == user.UID)
                {
                    list.Add(user);
                }
            }
            return list;
        }


        /// <summary>
        /// Search for a specific sBID, then return all new found borrow data to a list
        /// </summary>
        /// <param name="sBID"></param>
        /// <returns></returns>
        public List<Borrow_Data> search_for_BID(string sBID)
        {
            List<Borrow_Data> list = new List<Borrow_Data>();
            foreach (Borrow_Data user in retrieve_all_borrows())
            {
                if (sBID == user.BID)
                {
                    list.Add(user);
                }
            }
            return list;
        }
        #endregion
    }
}
