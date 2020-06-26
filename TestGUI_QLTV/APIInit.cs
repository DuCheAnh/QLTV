using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestGUI_QLTV
{
    public static class APIInit
    {
        public static HttpClient Apiclient { get; set; }

        public static string Token = "";

        public static void InitClient()
        {
            Apiclient = new HttpClient();
            Apiclient.BaseAddress = new Uri("https://localhost:5001/");//44331
            Apiclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            Apiclient.DefaultRequestHeaders.Accept.Clear();
            Apiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void AttatchToken(string token)
        {
            Token = token;
        }
    }
}
