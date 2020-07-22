using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestGUI_QLTV
{
    // put this http client as static to make sure only one port is being open at one specifictime no overlaps
    public static class APIInit
    {
        public static HttpClient Apiclient { get; set; }

        public static string URL = "https://qqhasagi.herokuapp.com/";

        public static void InitClient()
        {
            Apiclient = new HttpClient();
            Apiclient.BaseAddress = new Uri("http://localhost:5000/");//44331
            Apiclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Data_Context.Token);

            Apiclient.DefaultRequestHeaders.Accept.Clear();
            Apiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
