using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;

namespace BUS_QuanLy
{
    public static class BUS_Book
    {
        static DAL_Book DAL_method = new DAL_Book();

        public static IEnumerable<Book_Data> Get_all_books()
        {
            DAL_method.init_client();
            return DAL_method.retrieve_all_books();
        }

        public static Book_Data Retrive_book_data(string v)
        {
            DAL_method.init_client();
            return DAL_method.retrieve_book_data(v);
        }

        public static bool Create_new_book(Book_Data data)
        {
            DAL_method.init_client();
            if (DAL_method.add_new_book(data.name, data.author, data.release_date, data.category, data.description, data.cover_page, data.price, data.amount))
                return true;
            return false;
        }

        public static bool Update_on_book(Book_Data book)
        {
            DAL_method.init_client();
            return DAL_method.update_book_data(book);
        }

        public static IEnumerable<Book_Data> Search(string text)
        {
            DAL_method.init_client();
            List<Book_Data> bookdatas = DAL_method.retrieve_all_books();
            List<Book_Data> searchingBooks = new List<Book_Data>();
            foreach (Book_Data books in bookdatas)
            {
                if (books.name.Contains(text) || books.author.Contains(text) || books.category.Contains(text) || books.description.Contains(text))
                    searchingBooks.Add(books);
            }
            return searchingBooks;
        }

        public static void Delete_specific_book(string id)
        {
            DAL_method.init_client();
            DAL_method.delete_book(id);
        }
    }
}
