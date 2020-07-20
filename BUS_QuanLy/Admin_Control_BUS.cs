using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace BUS_QuanLy
{
    public class Admin_Control_BUS
    {
        DAL_Account Account_DAL = new DAL_Account();
        DAL_Libcard Libcard_DAL = new DAL_Libcard();
        DAL_Book Book_DAL = new DAL_Book();
        /// <summary>
        /// gan data tu DAl => grid trong GUI
        /// </summary>
        /// <param name="Info_grid"></param>
        public void Get_User_Info(DataGrid Info_grid)
        {
            Account_DAL.init_client();
            // Info_grid.ItemsSource = Account_DAL.retrieve_all_user_data();
        }

        /// <summary>
        /// 1) dang le phai check kieu data truoc khi truyen xuong dal
        /// 2) truyen list nhung user can phai update xuong dal
        /// </summary>
        /// <param name="Updated_Users"></param>
        public void Update_User_Info(List<Account_Data> Updated_Users)
        {
            Account_DAL.init_client();
            //Acount_DAL.Update_Users_data(Updated_Users);
        }

        /// <summary>
        /// Create a new libcards
        /// </summary>
        /// <param name="sAccountType"></param>
        /// <param name="sIdentityCard"></param>
        /// <param name="sName"></param>
        /// <param name="dDOB"></param>
        /// <param name="bGender"></param>
        /// <returns></returns>
        public bool create_new_libcard(string sAccountType, string sIdentityCard
                    , string sName, string dDOB, bool bGender)
        {
            Libcard_DAL.init_client();
            return Libcard_DAL.create_new_libcard(sAccountType, sIdentityCard, sName, dDOB, bGender);
        }

        public List<LibCard_Data> all_libcard_data()
        {
            Libcard_DAL.init_client();
            return Libcard_DAL.retrieve_all_libcard();
        }

        public bool add_new_book(string sName, string sAuthor, int nReleaseYear, string sCategory,
                                 string sDescription, string sCoverPage, int nPrice, int nAmount)
        {
            Book_DAL.init_client();
            return Book_DAL.add_new_book(sName, sAuthor, nReleaseYear, sCategory, sDescription, sCoverPage, nPrice, nAmount);
        }
        public bool update_book_info(string sBID, string sName, string sAuthor, int nReleaseYear, string sCategory,
                                        string sDescription, string sCoverPage, int nPrice, int nAmount)
        {
            Book_DAL.init_client();
            return Book_DAL.update_book_info(sBID, sName, sAuthor, nReleaseYear, sCategory, sDescription, sCoverPage, nPrice, nAmount);
        }

        public Book_Data retrieve_book_data(string sBID)
        {
            Book_DAL.init_client();
            return Book_DAL.retrieve_book_data(sBID);
        }
        public bool delete_book(string sBID)
        {
            Book_DAL.init_client();
            return Book_DAL.delete_book(sBID);
        }
        public List<Book_Data> all_books_data()
        {
            Book_DAL.init_client();
            return Book_DAL.retrieve_all_books();
        }
        public bool update_book_data(Book_Data data)
        {
            Book_DAL.init_client();
            return Book_DAL.update_book_data(data);
        }
    }
}
