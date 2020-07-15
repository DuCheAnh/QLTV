using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using Newtonsoft.Json;

namespace TestGUI_QLTV.Processor
{
    public static class Account_data_Processor
    {
        #region Get method
        public static async Task<Account_Data> GetAccount(string id)
        {
            try
            {

                string url = APIInit.URL + $"api/account/{ id }";

                using (HttpResponseMessage response = await APIInit.Apiclient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var Account = response.Content.ReadAsAsync<Account_Data>().Result;

                        return Account;
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
        #endregion

        #region Post method

        public static async Task<bool> Check_current_password(string UID, string OldPassword)
        {
            string url = APIInit.URL + $"api/account/{UID}/checkoldPassword";

            HttpResponseMessage response = await APIInit.Apiclient.PostAsJsonAsync(url, OldPassword);

            bool IsMatch = response.Content.ReadAsAsync<bool>().Result;
            return IsMatch;
        }

        public static async Task<bool> Register(string username, string password, string email)
        {
            string url = APIInit.URL + $"api/Account";

            UserRegister register = new UserRegister() { Username = username, Password = password, Email = email };
            HttpResponseMessage response = await APIInit.Apiclient.PostAsJsonAsync(url, register);

            bool Created = response.Content.ReadAsAsync<bool>().Result;

            return Created;
        }
        #region authentication
        public static async Task<bool> Authentication(UserCred usercred)
        {
            try

            {
                string url = APIInit.URL + $"api/account/authenticate";

                using (HttpResponseMessage response = await APIInit.Apiclient.PostAsJsonAsync(url, usercred))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsAsync<UserToken>().Result;
                        Data_Context.currentUID  = content.ID;

                        Data_Context.Token = content.token.ToString();

                        return true;
                    }

                }
            }
            catch (Exception) { }
            return false;
        }
        #endregion
        #endregion

        #region Put method
        public static async void PUT_change_email(string UID, string newEmail)
        {
            string url = APIInit.URL + $"api/account/{UID}/changeEmail";

            HttpResponseMessage response = await APIInit.Apiclient.PutAsJsonAsync(url, newEmail);

            Data_Context.currentAccount = await Account_data_Processor.GetAccount(Data_Context.currentUID);
        }

        public static async void PUT_change_password(string UID, string newPassword)
        {
            string url = APIInit.URL + $"api/account/{UID}/changePassword";

            HttpResponseMessage response = await APIInit.Apiclient.PutAsJsonAsync(url, newPassword);

            Data_Context.currentAccount = await Account_data_Processor.GetAccount(Data_Context.currentUID);
        }
        #endregion
    }
}
