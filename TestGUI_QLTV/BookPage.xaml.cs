using BUS_QuanLy;
using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.Generic;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : UserControl
    {
        #region variables
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        public User_Control_BUS user_control = new User_Control_BUS();
        int maximumborrow = 0;
        #endregion
        public BookPage()
        {
            Data_Context.BorrowedBook = admin_control.search_for_UID(Data_Context.currentUID);
            InitializeComponent();
            init_book_page();
            if (Data_Context.currentAccount.account_type!=null)
            {
                maximumborrow = user_control.retrieve_usertype(Data_Context.currentAccount.account_type).maximum_borrows;
            }
            Console.WriteLine(maximumborrow);
            if (Data_Context.currentAccount.LCID==null || Data_Context.currentAccount.LCID=="") BorrowButton.IsEnabled = false;
        }
        #region initiation
        private void AmountLeftTextBlock_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            AmountLeftTextBlock.Text += " in stock";
        }

        public void init_book_page()
        {
            this.NameTextBlock.Text = Data_Context.selected_book.name;
            this.AuthorTextBlock.Text = Data_Context.selected_book.author;
            this.AmountLeftTextBlock.Text = Data_Context.selected_book.left.ToString() + " in stocks";
            this.ReleaseYearTextBlock.Text = "xuất bản " + Data_Context.selected_book.release_year.ToString();
            this.DescriptionTextBlock.Text = Data_Context.selected_book.description;
            if (Data_Context.selected_book.left < 1) this.BorrowButton.IsEnabled = false;
        }
        #endregion

        #region button clicks
         void BorrowButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //user_control.add_borrow_data(Data_Context.selected_book.BID, Data_Context.currentUID, DateTime.Now);   
            List<string> brlist=user_control.get_user_BrID(Data_Context.currentAccount);
            Console.WriteLine(brlist.Count);
            if (Data_Context.onWishList != null && user_control.get_user_BrID(Data_Context.currentAccount).Count < maximumborrow)
            {
                if (Data_Context.selected_book.left > 0 &&Data_Context.onWishList.Count<maximumborrow && Data_Context.onWishList.Count<(maximumborrow-brlist.Count)
                    && Data_Context.onWishList.Where(x => x.BID == Data_Context.selected_book.BID).ToList().Count < Data_Context.selected_book.left)
                {
                    Data_Context.onWishList.Add(Data_Context.selected_book);
                    popup_message("Added to wishlist1");
                }
                else
                {
                    popup_message("Cart is full");
                }
            }
            else if (user_control.get_user_BrID(Data_Context.currentAccount).Count < maximumborrow && Data_Context.onWishList.Count < (maximumborrow - brlist.Count))
            {
                Data_Context.onWishList.Add(Data_Context.selected_book);
                popup_message("Added to wishlist2");
            }
            else
            {
                popup_message("Can't add more");
            }
        }
        void popup_message(string message)
        {
            TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
            popup.PopUpTB.Text = message;
            popup.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Show();
        }
        #endregion
    }
}
