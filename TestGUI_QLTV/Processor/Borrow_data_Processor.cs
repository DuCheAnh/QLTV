using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace TestGUI_QLTV.Processor
{
    public static class Borrow_data_Processor
    {
        #region Get method
        public static async Task<List<Borrow_Data>> retrieve_all_borrows()
        {
            List<Borrow_Data> borrows = new List<Borrow_Data>();
            APIInit.InitClient();
            string url = APIInit.URL + $"api/BorrowHistory";

            try
            {
                using (HttpResponseMessage response = await APIInit.Apiclient.GetAsync(url))
                {
                    if(response.IsSuccessStatusCode)
                    {
                        borrows = response.Content.ReadAsAsync<List<Borrow_Data>>().Result;
                    }
                }
            }
            catch (Exception) { }
            return borrows;
        }

        #endregion

        #region Post method
        public static async Task add_borrow_data(string bID, string currentUID, DateTime now)
        {
            Borrow_Data data = new Borrow_Data();
            data.BID = bID;
            data.UID = currentUID;
            data.borrow_date = now;
            APIInit.InitClient();
            string url = APIInit.URL + $"api/BorrowHistory";
            try
            {
                HttpResponseMessage response = await APIInit.Apiclient.PostAsJsonAsync(url, data);
            }
            catch (Exception) { }

        }


        #endregion

        #region Put method
        #endregion

        #region Delete method
        #endregion
    }
}
