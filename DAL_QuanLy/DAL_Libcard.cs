using DTO_QuanLy;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;

namespace DAL_QuanLy
{
    public class DAL_Libcard : DB_connect
    {
        #region variables
        //variables
        public IFirebaseClient client;
        public string sLibCardTable_path = "LibCards/";
        #endregion
        //Connect to the database, run this before all the funcs below
        public void init_client()
        {


            client = new FireSharp.FirebaseClient(config);
        }
        #region functions
        /// <summary>
        /// Add a new libcard info to the database
        /// </summary>
        /// <param name="sAccountType"></param>
        /// <param name="sIdentityCard"></param>
        /// <param name="sName"></param>
        /// <param name="dDOB"></param>
        /// <param name="bGender"></param>
        /// <returns></returns>
        public bool create_new_libcard(string sAccountType, string sIdentityCard
                    , string sName, string dDOB, bool bGender)
        {
            try
            {
                string sLCID = DateTime.Now.Ticks.ToString().Substring(1);
                var data = new LibCard_Data(sAccountType, sIdentityCard, sName, dDOB, bGender);
                data.created_date = DateTime.Now;
                data.LCID = sLCID;
                SetResponse response = client.Set(sLibCardTable_path + sLCID, data);
                LibCard_Data result = response.ResultAs<LibCard_Data>();
                if (result != null) return true;
            }
            catch (Exception) { }
            return false;
        }


        /// <summary>
        /// Delete a specific sLCID from the table
        /// </summary>
        /// <param name="sLCID"></param>
        /// <returns></returns>
        public bool delete_libcard(string sLCID)
        {
            try
            {
                FirebaseResponse delete_response = client.Delete(sLibCardTable_path + sLCID);
                if (delete_response != null)
                {
                    return true;
                }

            }
            catch (Exception) { }
            return false;
        }


        /// <summary>
        /// Retrieve libcard data specificly by its LCID, then check its availability
        /// </summary>
        /// <param name="sLCID"></param>
        /// <returns></returns>
        public LibCard_Data retrieve_libcard_data(string sLCID)
        {
            var retrieve_response = client.Get(sLibCardTable_path + sLCID);
            LibCard_Data data = retrieve_response.ResultAs<LibCard_Data>();
            update_libcard_expiration(data, still_available(data));
            return data;
        }


        /// <summary>
        /// Retrieve all libcard data then check their availability
        /// </summary>
        /// <returns></returns>
        public List<LibCard_Data> retrieve_all_libcard()
        {
            //create a new list to store libcard
            List<LibCard_Data> libcard_list = new List<LibCard_Data>();
            //retrieve all info and then store it into libcard_list
            FirebaseResponse response = client.Get(sLibCardTable_path);
            Dictionary<string, LibCard_Data> all_data = response.ResultAs<Dictionary<string, LibCard_Data>>();
            foreach (var libcard in all_data)
            {
                update_libcard_expiration(libcard.Value, still_available(libcard.Value));
                libcard_list.Add(libcard.Value);
            }
            return libcard_list;
        }


        /// <summary>
        /// Update libcard expiration status
        /// </summary>
        /// <param name="libcard"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool update_libcard_expiration(LibCard_Data libcard, bool value)
        {
            libcard.expired = !value;
            FirebaseResponse response = client.Update(sLibCardTable_path + libcard.LCID, libcard);
            LibCard_Data data = response.ResultAs<LibCard_Data>();
            if (data != null) return true;
            else return false;
        }

        public bool update_libcard_usedable(string libcard, bool value)
        {
            LibCard_Data libcard_data = retrieve_libcard_data(libcard);
            libcard_data.used = value;
            FirebaseResponse response = client.Update(sLibCardTable_path + libcard_data.LCID, libcard);
            LibCard_Data data = response.ResultAs<LibCard_Data>();
            if (data != null) return true;
            else return false;
        }

        /// <summary>
        /// Search for libcard name, then return if found
        /// </summary>
        /// <param name="sName"></param>
        /// <returns></returns>
        public LibCard_Data search_for_name(string sName)
        {
            foreach (LibCard_Data libcard in retrieve_all_libcard())
            {
                if (libcard.name == sName)
                {
                    return libcard;
                }
            }
            return null;
        }


        /// <summary>
        /// Search for libcard IDcard, then return if found
        /// </summary>
        /// <param name="sIDCard"></param>
        /// <returns></returns>
        public LibCard_Data search_for_IDCard(string sIDCard)
        {
            foreach (LibCard_Data libcard in retrieve_all_libcard())
            {
                if (libcard.identity_card == sIDCard)
                {
                    return libcard;
                }
            }
            return null;
        }

        /// <summary>
        /// Check libcard availability
        /// </summary>
        /// <param name="libcard"></param>
        /// <returns></returns>
        public bool still_available(LibCard_Data libcard)
        {
            if ((DateTime.Now - libcard.created_date).TotalDays > 30)
            {
                return false;
            }
            else return true;
        }
        #endregion
    }
}
