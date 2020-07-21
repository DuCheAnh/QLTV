using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
namespace TestGUI_QLTV
{
    public static class Data_Context
    {
        public static string currentUID { get; set; }
        public static Account_Data currentAccount;

        public static List<Book_Data> currentHomePageBook;

        public static Book_Data selected_book;
    }
}
