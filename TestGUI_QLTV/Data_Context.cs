using DTO_QuanLy;
using System.Collections.Generic;
namespace TestGUI_QLTV
{
    public static class Data_Context
    {
        public static string currentUID { get; set; }
        public static Account_Data currentAccount;

        public static List<Book_Data> currentHomePageBook;

        public static Book_Data selected_book;
        public static List<Borrow_Data> BorrowedBook;
        public static List<Book_Data> onWishList = new List<Book_Data>();
        public static bool isAdmin;
    }
}
