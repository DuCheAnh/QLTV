using DTO_QuanLy;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;

namespace DAL_QuanLy
{
    class DAL_UserType : DB_connect
    {
        public IFirebaseClient client;
        string sUserTypeTable_Path = "Library/UserType/";
        public void init_client()
        {
            client = new FireSharp.FirebaseClient(config);
        }
        public bool add_user_type(string sName, int nExp, int nMaxBorrow, int nBorrowTime, float fLostPercentage,
                                  float fDamagedPercentage, int nExtendTime, int nPrice)
        {
            var data = new UserType_Data
            {
                name = "sName",
                expiration_time = nExp,
                maximum_borrows = nMaxBorrow,
                borrow_time = nBorrowTime,
                lost_percentage = fLostPercentage,
                damaged_percentage = fDamagedPercentage,
                extend_time = nExtendTime,
                price = nPrice
            };
            SetResponse response = client.Set(sUserTypeTable_Path + data.name, data);
            UserType_Data result = response.ResultAs<UserType_Data>();
            if (result != null) return true;
            return false;
        }
        public bool delete_usertype(string sUserTypeName)
        {
            try
            {
                FirebaseResponse delete_response = client.Delete(sUserTypeTable_Path + sUserTypeName);
                if (delete_response != null) return true;
            }
            catch (Exception) { }
            return false;
        }
        public UserType_Data retrieve_usertype_data(string sUserTypeName)
        {
            var retrieve_response = client.Get(sUserTypeTable_Path + sUserTypeName);
            if (retrieve_response.Body != "null")
            {
                UserType_Data data = retrieve_response.ResultAs<UserType_Data>();
                return data;
            }
            return null;
        }
        public List<UserType_Data> retrieve_all_usertype()
        {
            //create a list to store data
            List<UserType_Data> usertype_list = new List<UserType_Data>();
            //get all the data, then transfer them to a dictionnary variable
            FirebaseResponse response = client.Get(sUserTypeTable_Path);
            Dictionary<string, UserType_Data> all_data = new Dictionary<string, UserType_Data>();
            if (response.Body != "null")
            {
                all_data = response.ResultAs<Dictionary<string, UserType_Data>>();
            }
            foreach (var user in all_data)
            {
                usertype_list.Add(user.Value);
            }
            return usertype_list;
        }
    }
}
