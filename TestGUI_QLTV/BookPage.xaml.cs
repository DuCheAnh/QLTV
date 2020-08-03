using BUS_QuanLy;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : UserControl
    {
        #region variables
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        User_Control_BUS user_control = new User_Control_BUS();
        #endregion
        public BookPage()
        {
            Data_Context.BorrowedBook = admin_control.search_for_UID(Data_Context.currentUID);
            InitializeComponent();
            init_book_page();
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
        private void BorrowButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //user_control.add_borrow_data(Data_Context.selected_book.BID, Data_Context.currentUID, DateTime.Now);
            Data_Context.onWishList.Add(Data_Context.selected_book);
            TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
            popup.PopUpTB.Text = "added to wishlist";
            popup.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Show();
        }
        #endregion
    }
}
