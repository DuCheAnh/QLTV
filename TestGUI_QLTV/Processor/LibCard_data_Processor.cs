using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace TestGUI_QLTV.Processor
{
    public static class LibCard_data_Processor
    {
        #region Get method
        public static async Task<List<LibCard_Data>> Get_all_unused_libcard(string UID)
        {
            string url = APIInit.URL + "api/libcard";
            List<LibCard_Data> libcards = new List<LibCard_Data>();
            List<LibCard_Data> data = new List<LibCard_Data>();
            Account_Data userdata = await Account_data_Processor.GetAccount(UID);

            try
            {
                using (HttpResponseMessage response = await APIInit.Apiclient.GetAsync(url))
                {
                    if (response.Content != null)
                    {
                        libcards = response.Content.ReadAsAsync<List<LibCard_Data>>().Result;
                    }
                }
            }
            catch (Exception)
            { }

            foreach (LibCard_Data libcard in libcards)
            {
                if (libcard.LCID == userdata.LCID)
                    data.Add(libcard);
            }

            foreach (LibCard_Data libcard in libcards)
            {
                if (libcard.used == false)
                    data.Add(libcard);
            }


            return data;
        }

        public static async Task<List<LibCard_Data>> Get_all_libcard_data()
        {
            string url = APIInit.URL + "api/libcard";
            List<LibCard_Data> libcards = new List<LibCard_Data>();

            try
            {
                using (HttpResponseMessage response = await APIInit.Apiclient.GetAsync(url))
                {
                    if (response.Content != null)
                    {
                        libcards = response.Content.ReadAsAsync<List<LibCard_Data>>().Result;
                    }
                }
            }
            catch (Exception) { }

            return libcards;
        }



        #endregion

        #region Post method
        public static async Task<bool> create_new_libcard(string accounttype, string identitycard, string name, string DOB, bool bGender)
        {
            APIInit.InitClient();

            LibCard_Data data = new LibCard_Data();
            data.account_type = accounttype;
            data.identity_card = identitycard;
            data.name = name;
            data.DOB = DOB;
            data.gender = bGender;

            string url = APIInit.URL + $"api/libcard";

            try
            {
                using (HttpResponseMessage response = await APIInit.Apiclient.PostAsJsonAsync(url, data))
                {
                    if (response.IsSuccessStatusCode)
                        return response.Content.ReadAsAsync<bool>().Result;
                }
            }
            catch (Exception) { }

            return false;
        }
        #endregion

        #region Put method
        public static async Task Update_LibCard_Usable(string LCID , bool used)
        {
            string url = APIInit.URL + $"api/libcard/{LCID}/useable";

            try
            {
                HttpResponseMessage response = await APIInit.Apiclient.PutAsJsonAsync(url, used);
            }
            catch (Exception) { }

        }

        #endregion

        #region Delete method
        #endregion

    }
}
