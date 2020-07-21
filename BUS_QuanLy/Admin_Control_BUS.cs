using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BUS_QuanLy
{
    public class Admin_Control_BUS
    {
        DAL_Account Account_DAL = new DAL_Account();
        DAL_Libcard Libcard_DAL = new DAL_Libcard();
        DAL_Book Book_DAL = new DAL_Book();

        List<Account_Data> possible_account = new List<Account_Data>();
        /// <summary>
        /// gan data tu DAl => grid trong GUI
        /// </summary>
        /// <param name="Info_grid"></param>
        public void Get_User_Info(DataGrid Info_grid)
        {
            Account_DAL.init_client();
            // Info_grid.ItemsSource = Account_DAL.retrieve_all_user_data();
        }

        public void Delete_account(string uID)
        {
            Account_DAL.init_client();
            Account_DAL.delete_user(uID);
        }

        /// <summary>
        /// 1) dang le phai check kieu data truoc khi truyen xuong dal
        /// 2) truyen list nhung user can phai update xuong dal
        /// </summary>
        /// <param name="Updated_Users"></param>
        public void Update_Users_Info(List<Account_Data> Updated_Users)
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

        public List<LibCard_Data> Get_all_unused_libcard(string UID)
        {
            Libcard_DAL.init_client();
            Account_DAL.init_client();
            List<LibCard_Data> libcards = new List<LibCard_Data>();

            libcards = Libcard_DAL.retrieve_all_libcard();

            List<LibCard_Data> data = new List<LibCard_Data>();

            foreach (LibCard_Data libcard in libcards)
            {
                if (libcard.LCID == Account_DAL.retrieve_user_data(UID).LCID)
                    data.Add(libcard);
            }

            foreach (LibCard_Data libcard in libcards)
            {
                if (libcard.used == false)
                    data.Add(libcard);
            }


            return data;
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

        public void Update_User_data(Account_Data data)
        {
            Account_DAL.init_client();
            Account_DAL.update_user_data(data);
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

        public List<Account_Data> all_accounts_data()
        {
            Account_DAL.init_client();
            return Account_DAL.retrieve_all_user();
        }

        public bool LoginMethod(string username, string Password)
        {
            Account_DAL.init_client();
            possible_account = Account_DAL.retrieve_all_user();

            foreach (Account_Data account in possible_account)
            {
                if (account.account == username && account.password == Password)
                    return true;
            }

            return false;
        }

        public bool RegisterIn(string Account, string Password, string Email)
        {

            Account_DAL.init_client();
            possible_account = Account_DAL.retrieve_all_user();

            if (Account_DAL.search_for_account(Account) == null)
            {
                return Account_DAL.create_new_user(Account, Password, Email);
            }
            else
            {
                MessageBox.Show("");

            }
            return false;

        }
    }
} 

