using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Response;
using FireSharp.Config;
using FireSharp.Interfaces;
using DTO_QuanLy;
using Microsoft.Win32;

namespace DAL_QuanLy
{
    public class DAL_Account : DB_connect
    {
        #region variables
        //variables
        public IFirebaseClient client;
        string sAccountTable_path = "LibAccounts/";
        #endregion

        //constructor
        public DAL_Account()
        {
            init_client();
        }


        //Connect to the database, run this before all the funcs below
        public void init_client()
        {
            client = new FireSharp.FirebaseClient(config);
        }


        #region function
        /// <summary>
        /// Create a new user using Sign up info (account,password,email)
        /// <list type="bullet">
        /// <item>UserID are automatically generated</item>
        /// <item>Account and password must not be null and acquire certain requirements</item>
        /// <item>Email can be set to null</item>
        /// </list>
        /// </summary>
        /// <param name="sAccount"></param>
        /// <param name="sPassword"></param>
        /// <param name="sEmail"></param>
        public bool create_new_user(string sAccount, string sPassword, string sEmail)
        {
            try
            {
                //generate user id
                string sUID = "U" + DateTime.Now.Ticks.ToString();
                var data = new Account_Data(sAccount, sPassword, sEmail);
                data.UID = sUID;
                //add a new user info
                SetResponse response = client.Set(sAccountTable_path + sUID, data);
                Account_Data result = response.ResultAs<Account_Data>();
                if (result != null) return true;
            }
            catch (Exception)
            {

            }
            return false;
        }


        /// <summary>
        /// Update users password by uid and password
        /// <list type="bullet">
        /// <item>Password must be valid</item>
        /// </list>
        /// </summary>
        /// <param name="sUID"></param>
        /// <param name="sPassword"></param>
        public bool update_user_password(string sUID, string sPassword)
        {
            try
            {
                //get user from suid
                Account_Data data = retrieve_user_data(sUID);
                data.password = sPassword;
                //update users info
                FirebaseResponse update_response = client.Update(sAccountTable_path + sUID, data);
                Account_Data result = update_response.ResultAs<Account_Data>();
                if (result != null) return true;
            }
            catch (Exception)
            {

            }
            return false;
        }


        /// <summary>
        /// Update users email by uid and email
        /// <list type="bullet">
        /// <item>Email must be valid</item>
        /// </list>
        /// </summary>
        /// <param name="sUID"></param>
        /// <param name="sEmail"></param>
        public bool update_user_email(string sUID, string sEmail)
        {
            try
            {
                //get user from suid
                Account_Data data = retrieve_user_data(sUID);
                data.email = sEmail;
                //update users info
                FirebaseResponse update_response = client.Update(sAccountTable_path + sUID, data);
                Account_Data result = update_response.ResultAs<Account_Data>();
                if (result != null) return true;
            }
            catch (Exception) { }
            return false;
        }


        /// <summary>
        /// Update users password by uid and profile picture
        /// <list type="bullet">
        /// <item>Profile picture must be valid</item>
        /// </list>
        /// </summary>
        /// <param name="sUID"></param>
        /// <param name="sProfilePicture"></param>
        public bool update_user_profile(string sUID, string sProfilePicture)
        {
            try
            {
                //get user from suid
                Account_Data data = retrieve_user_data(sUID);
                data.profile_picture = sProfilePicture;
                //update users info
                FirebaseResponse update_response = client.Update(sAccountTable_path + sUID, data);
                Account_Data result = update_response.ResultAs<Account_Data>();
                if (result != null) return true;
            }
            catch (Exception) { }
            return false;
        }


        /// <summary>
        /// Delete user from the database by UID
        /// </summary>
        /// <param name="sUID"></param>
        public bool delete_user(string sUID)
        {
            try
            {
                FirebaseResponse delete_response = client.Delete(sAccountTable_path + sUID);
                if (delete_response != null) return true;
            }
            catch (Exception) { }
            return false;
        }


        /// <summary>
        /// Retrieve users data by UID, the function return Account_Data class
        /// </summary>
        /// <param name="sUID"></param>
        /// <returns></returns>
        public Account_Data retrieve_user_data(string sUID)
        {
            var retrieve_response = client.Get(sAccountTable_path + sUID);
            Account_Data data = retrieve_response.ResultAs<Account_Data>();
            return data;
        }


        /// <summary>
        /// transfer libcard data to users and send it to the database
        /// </summary>
        /// <param name="sUID"></param>
        /// <param name="sLCID"></param>
        public bool set_libcard_to_user(string sUID, string sLCID)
        {
            try
            {
                DAL_Libcard Libcard_rep = new DAL_Libcard();
                //get user            
                Account_Data user_data = retrieve_user_data(sUID);
                //get libcard
                var libcard_response = client.Get(Libcard_rep.sLibCardTable_path + sLCID);
                LibCard_Data libcard_data = libcard_response.ResultAs<LibCard_Data>();
                //set new data
                user_data.name = libcard_data.name;
                user_data.DOB = libcard_data.DOB;
                user_data.gender = libcard_data.gender;
                user_data.identity_card = libcard_data.identity_card;
                user_data.account_type = libcard_data.account_type;
                //send it to the database
                FirebaseResponse update_response = client.Update(sAccountTable_path + sUID, user_data);
                Account_Data result = update_response.ResultAs<Account_Data>();
                if (result != null) return true;
            }
            catch (Exception) { }
            return false;
        }


        /// <summary>
        /// Remove libcard info from user
        /// </summary>
        /// <param name="sUID"></param>
        public bool remove_libcard(string sUID)
        {
            try
            {
                Account_Data data = retrieve_user_data(sUID);
                Account_Data data1 = new Account_Data(data.account, data.password, data.email);
                FirebaseResponse remove_response = client.Set(sAccountTable_path + sUID, data1);
                Account_Data result = remove_response.ResultAs<Account_Data>();
                if (result != null) return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        /// <summary>
        /// Get all users data, then add them all to a list
        /// </summary>
        /// <returns></returns>
        public List<Account_Data> retrieve_all_user()
        {
            //create a list to store data
            List<Account_Data> account_list = new List<Account_Data>();
            //get all the data, then transfer them to a dictionnary variable
            FirebaseResponse response = client.Get(sAccountTable_path);
            Dictionary<string, Account_Data> all_data = response.ResultAs<Dictionary<string, Account_Data>>();
            foreach (var user in all_data)
            {
                account_list.Add(user.Value);
            }
            return account_list;
        }


        /// <summary>
        /// Search for username, if found return user as account_data, if not return null
        /// </summary>
        /// <param name="sAccount"></param>
        /// <returns></returns>
        public Account_Data search_for_account(string sAccount)
        {
            foreach (Account_Data user in retrieve_all_user())
            {
                if (sAccount == user.account)
                {
                    return user;
                }
            }
            return null;
        }


        /// <summary>
        /// update user base on new account data
        /// </summary>
        /// <param name="sUID"></param>
        /// <param name="sProfilePicture"></param>
        /// <returns></returns>
        public bool update_user_data(Account_Data account)
        {
            try
            {
                FirebaseResponse update_response = client.Update(sAccountTable_path + account.UID, account);
                Account_Data result = update_response.ResultAs<Account_Data>();
                if (result != null) return true;
            }
            catch (Exception) { }
            return false;
        }
        #endregion
    }
}
