using DTO_QuanLy;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;

namespace DAL_QuanLy
{
    public class DAL_Book : DB_connect
    {
        #region variables
        //variables
        public IFirebaseClient client;
        string sBookTable_path = "Books/";
        #endregion
        //Connect to the database, run this before all the funcs below
        public void init_client()
        {
            client = new FireSharp.FirebaseClient(config);
        }
        #region functions
        #region BID generator
        private string get_first_letters(string value)
        {
            string result = null;
            result += value[0].ToString();
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i].ToString() == " ")
                {
                    result += value[i + 1].ToString();
                }
            }
            return result;
        }
        private string create_new_bid(Book_Data book)
        {
            string part1 = get_first_letters(book.name);
            string part2 = get_first_letters(book.author);
            string part3 = book.release_year.ToString();
            string result = part1 + part2 + part3;
            return result;
        }
        #endregion


        /// <summary>
        /// Add new book_data to the database, then return true if succeeded, false if not
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="sAuthor"></param>
        /// <param name="nReleaseYear"></param>
        /// <param name="sCategory"></param>
        /// <param name="sDescription"></param>
        /// <param name="sCoverPage"></param>
        /// <param name="nPrice"></param>
        /// <param name="nAmount"></param>
        /// <returns></returns>
        public bool add_new_book(string sName, string sAuthor, int nReleaseYear, string sCategory,
                                string sDescription, string sCoverPage, int nPrice, int nAmount)
        {
            try
            {
                var data = new Book_Data(sName, sAuthor, nReleaseYear, sCategory, sDescription, sCoverPage, nPrice, nAmount);
                data.BID = create_new_bid(data);
                SetResponse response = client.Set(sBookTable_path + data.BID, data);
                Book_Data result = response.ResultAs<Book_Data>();
                if (result != null) return true;
            }
            catch (Exception)
            {

            }
            return false;
        }


        /// <summary>
        /// Update book info, then add it to the database
        /// </summary>
        /// <param name="sBID"></param>
        /// <param name="sName"></param>
        /// <param name="sAuthor"></param>
        /// <param name="nReleaseYear"></param>
        /// <param name="sCategory"></param>
        /// <param name="sDescription"></param>
        /// <param name="sCoverPage"></param>
        /// <param name="nPrice"></param>
        /// <param name="nAmount"></param>
        /// <returns></returns>
        public bool update_book_info(string sBID, string sName, string sAuthor, int nReleaseYear, string sCategory,
                                        string sDescription, string sCoverPage, int nPrice, int nAmount)
        {
            try
            {
                var data = new Book_Data(sName, sAuthor, nReleaseYear, sCategory, sDescription, sCoverPage, nPrice, nAmount);
                FirebaseResponse response = client.Update(sBookTable_path + sBID, data);
                Book_Data result = response.ResultAs<Book_Data>();
                if (result != null) return true;
            }
            catch (Exception)
            {

            }
            return false;
        }


        /// <summary>
        /// update book info by a new book_data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool update_book_data(Book_Data data)
        {
            FirebaseResponse response = client.Update(sBookTable_path + data.BID, data);
            Book_Data result = response.ResultAs<Book_Data>();
            if (result != null) return true;
            else return false;
        }
        /// <summary>
        /// Delete a single book info desired by its BID
        /// </summary>
        /// <param name="sBID"></param>
        /// <returns></returns>
        public bool delete_book(string sBID)
        {
            try
            {
                FirebaseResponse delete_response = client.Delete(sBookTable_path + sBID);
                if (delete_response != null) return true;
            }
            catch (Exception) { }
            return false;
        }


        /// <summary>
        /// Retrieve a single book data by its BID, the fnc returned Book_Data
        /// </summary>
        /// <param name="sBID"></param>
        /// <returns></returns>
        public Book_Data retrieve_book_data(string sBID)
        {
            FirebaseResponse retrieve_response = client.Get(sBookTable_path + sBID);
            Book_Data data = retrieve_response.ResultAs<Book_Data>();
            return data;
        }


        /// <summary>
        /// Retrieve all books data then store them to a list
        /// </summary>
        /// <returns></returns>        
        public List<Book_Data> retrieve_all_books()
        {
            //create a list to store data
            List<Book_Data> book_list = new List<Book_Data>();
            //get all the data, then transfer them to a dictionnary variable
            FirebaseResponse response = client.Get(sBookTable_path);
            Dictionary<string, Book_Data> all_data = response.ResultAs<Dictionary<string, Book_Data>>();
            foreach (var book in all_data)
            {
                book_list.Add(book.Value);
            }
            return book_list;
        }
        #endregion
    }
}
