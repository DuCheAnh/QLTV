using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace TestGUI_QLTV.Processor
{
    public static class Book_data_Processor
    {
        #region Get method
        // get method
        public static async Task<List<Book_Data>> Get_all_books()
        {
            APIInit.InitClient();
            string url = APIInit.URL + "api/Book";
            List<Book_Data> books_retrived = new List<Book_Data>();
            try
            {

                using (HttpResponseMessage response = await APIInit.Apiclient.GetAsync(url))
                {
                    if (response.Content != null)
                    {
                        books_retrived = response.Content.ReadAsAsync<List<Book_Data>>().Result;
                    }
                }
            }
            catch (Exception) { }

            return books_retrived;
        }

        public static async Task<List<Book_Data>> Search_Books(string text)
        {
            string url = APIInit.URL + $"api/Book/Search:{text}";
            List<Book_Data> books_retrived = new List<Book_Data>();

            try
            {
                using (HttpResponseMessage response = await APIInit.Apiclient.GetAsync(url))
                {
                    if (response.Content != null)
                    {
                        books_retrived = response.Content.ReadAsAsync<List<Book_Data>>().Result;
                    }
                }
            }
            catch (Exception) { }

            return books_retrived;
        }

        public static async Task<Book_Data> retrieve_book_data(string BID)
        {
            APIInit.InitClient();
            string url = APIInit.URL + $"api/Book/{BID}";
            Book_Data Book = new Book_Data();

            try
            {
                using (HttpResponseMessage response = await APIInit.Apiclient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Book = response.Content.ReadAsAsync<Book_Data>().Result;
                    }
                }
            }
            catch (Exception) { }

            return Book;
        }
        #endregion

        #region Post method
        //post method
        public static async Task<bool> Add_new_book(Book_Data book)
        {

            try
            {
                string url = APIInit.URL + $"api/Book";

                using (HttpResponseMessage response = await APIInit.Apiclient.PostAsJsonAsync(url, book))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception) { }


            return false;
        }
        #endregion

        #region Put method
        #endregion

        #region Delete method

        public static async Task Delete_specific_Book(string BID)
        {
            try
            {
                string url = APIInit.URL + $"api/Book/{BID}";

                using (HttpResponseMessage response = await APIInit.Apiclient.DeleteAsync(url)) ;
            }
            catch (Exception) { }
        }

        #endregion
    }
}
