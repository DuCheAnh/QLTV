using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BUS_QuanLy
{
    public class User_Control_BUS
    {
        #region Variables
        DAL_Account UserData = new DAL_Account();
        DAL_Book bookdata = new DAL_Book();
        List<Account_Data> possible_account = new List<Account_Data>();
        DAL_Borrow borrowdata = new DAL_Borrow();
        DAL_Libcard libcard_data = new DAL_Libcard();
        DAL_UserType usertype_libcard = new DAL_UserType();
        #endregion

        public User_Control_BUS()
        {
        }
        #region Account related
        public Account_Data Get_Single_UserInfo(string sUID)
        {
            UserData.init_client();
            return UserData.retrieve_user_data(sUID);
        }

        public List<string> get_user_BrID(Account_Data user)
        {
            UserData.init_client();
            return UserData.get_user_BrID(user);
        }

        /// <summary>
        /// Get users password by UID (UID must exist)
        /// </summary>
        /// <param name="sUID"></param>
        /// <returns></returns>
        public string get_user_password(string sUID)
        {
            return UserData.retrieve_user_data(sUID).password;
        }

        public bool Checking(string UID, string OldPassword)
        {
            UserData.init_client();
            Account_Data data = UserData.retrieve_user_data(UID);
            if (data.password == OldPassword)
                return true;
            return false;
        }

        public void change_user_Email(string currentUID, string newEmail)
        {
            UserData.init_client();
            UserData.update_user_email(currentUID, newEmail);
        }


        public bool set_libcard_to_user(string sLCID, string sUID)
        {
            UserData.init_client();
            return UserData.set_libcard_to_user(sUID, sLCID);
        }
        /// <summary>
        /// Get account password for signing in by user account
        /// <list type="bullet">
        /// <item>If user account doesn't exist return null</item>
        /// </list>
        /// </summary>
        /// <param name="sAccount"></param>
        /// <returns></returns>
        public string get_account_password(string sAccount)
        {
            UserData.init_client();
            if (UserData.search_for_account(sAccount) != null)
            {
                return UserData.search_for_account(sAccount).password;
            }
            else return null;
        }


        public Account_Data search_for_account(string sAccount)
        {
            UserData.init_client();

            return UserData.search_for_account(sAccount);
        }

        /// <summary>
        /// change users password to a new one, return true if succeeded, false if not
        /// </summary>
        /// <param name="sUID"></param>
        /// <param name="sNewPassword"></param>
        /// <returns></returns>
        public bool change_user_password(string sUID, string sNewPassword)
        {
            UserData.init_client();

            return UserData.update_user_password(sUID, sNewPassword);
        }
        public bool LoginMethod(string username, string Password)
        {
            UserData.init_client();
            possible_account = UserData.retrieve_all_user();

            foreach (Account_Data account in possible_account)
            {
                if (account.account == username && account.password == Password)
                    return true;
            }

            return false;
        }

        public bool RegisterIn(string Account, string Password, string Email)
        {

            UserData.init_client();
            possible_account = UserData.retrieve_all_user();

            if (UserData.search_for_account(Account) == null)
            {
                return UserData.create_new_user(Account, Password, Email);
            }
            else
            {
                MessageBox.Show("");

            }
            return false;
        }
        #endregion

        #region Borrow related
        public Borrow_Data retrieve_borrow_data(string sBrID)
        {
            borrowdata.init_client();
            return borrowdata.retrieve_borrow_data(sBrID);
        }
        public bool add_borrow_data(string sBID, string sUID, DateTime dBorrowDate,int returnafter)
        {
            borrowdata.init_client();
            return borrowdata.add_new_borrow(sBID, sUID, dBorrowDate,returnafter);
        }
        #endregion

        #region Book related
        public Book_Data retrieve_book_data(string sBID)
        {
            bookdata.init_client();
            return bookdata.retrieve_book_data(sBID);
        }
        public List<Book_Data> Get_all_Books()
        {
            bookdata.init_client();
            List<Book_Data> Books = bookdata.retrieve_all_books();
            return Books;
        }


        public List<Book_Data> Search_for_book(string text)
        {
            bookdata.init_client();
            List<Book_Data> bookdatas = bookdata.retrieve_all_books();
            List<Book_Data> searchingBooks = new List<Book_Data>();
            foreach (Book_Data books in bookdatas)
            {
                if (books.name.Contains(text) || books.author.Contains(text) || books.category.Contains(text) || books.description.Contains(text))
                    searchingBooks.Add(books);
            }
            return searchingBooks;
        }
        #endregion

        #region Libcard related
        public LibCard_Data Search_for_LCID(string sLCID)
        {
            libcard_data.init_client();
            foreach (LibCard_Data data in libcard_data.retrieve_all_libcard())
            {
                if (sLCID == data.LCID) return data;
            }
            return null;
        }
        #endregion
        public UserType_Data retrieve_usertype(string sName)
        {
            usertype_libcard.init_client();
            return usertype_libcard.retrieve_usertype_data(sName);
        }
    }

}
