using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using Newtonsoft.Json;

namespace TestGUI_QLTV.Processor
{
    public class Account_data_Processor
    { 

        public static async Task<Account_Data> GetAccount(string id)
        {
 
            string url = $"https://localhost:5001/api/account/{ id }";

            using (HttpResponseMessage response = await APIInit.Apiclient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var Account = response.Content.ReadAsAsync<Account_Data>().Result;

                    return Account;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

       public static async void Authentication(UserCred usercred)
        {
            string url = $"https://localhost:5001/api/account/authentication";

            using (HttpResponseMessage response = await APIInit.Apiclient.PostAsJsonAsync(url, usercred))
            {
                if (response.IsSuccessStatusCode)
                {
                    var token = response.Content.ReadAsAsync<string>().Result;
                    APIInit.Token = token;
                }
            }
        }
    }
}
