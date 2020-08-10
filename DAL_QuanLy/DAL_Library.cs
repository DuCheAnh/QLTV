using DTO_QuanLy.Properties;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;

namespace DAL_QuanLy
{
    class DAL_Library : DB_connect
    {
        public IFirebaseClient client;
        string sLibraryTable_Path = "Library/Info/";
        public void init_client()
        {
            client = new FireSharp.FirebaseClient(config);
        }
        public bool add_lib_info(string sName, string sLocation, string sManager)
        {
            var data = new Library_Data
            {
                name = sName,
                location = sLocation,
                manager = sManager
            };
            SetResponse response = client.Set(sLibraryTable_Path + data.name, data);
            Library_Data result = response.ResultAs<Library_Data>();
            if (result != null) return true;
            return false;
        }
        public bool delete_libinfo(string sLibraryName)
        {
            try
            {
                FirebaseResponse delete_response = client.Delete(sLibraryTable_Path + sLibraryName);
                if (delete_response != null) return true;
            }
            catch (Exception) { }
            return false;
        }
        public Library_Data retrieve_lib_data(string sLibraryName)
        {
            var retrieve_response = client.Get(sLibraryTable_Path + sLibraryName);
            if (retrieve_response.Body != "null")
            {
                Library_Data data = retrieve_response.ResultAs<Library_Data>();
                return data;
            }
            return null;
        }
        public List<Library_Data> retrieve_all_lib_info()
        {
            //create a list to store data
            List<Library_Data> libraryinfo_list = new List<Library_Data>();
            //get all the data, then transfer them to a dictionnary variable
            FirebaseResponse response = client.Get(sLibraryTable_Path);
            Dictionary<string, Library_Data> all_data = new Dictionary<string, Library_Data>();
            if (response.Body != "null")
            {
                all_data = response.ResultAs<Dictionary<string, Library_Data>>();
            }
            foreach (var user in all_data)
            {
                libraryinfo_list.Add(user.Value);
            }
            return libraryinfo_list;
        }
    }
}
