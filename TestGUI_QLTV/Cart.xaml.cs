using BUS_QuanLy;
using DTO_QuanLy;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : UserControl
    {
        User_Control_BUS User_Control = new User_Control_BUS();
        public Cart()
        {
            InitializeComponent();
            init();
        }
        void init()
        {
            ICart.ItemsSource = Data_Context.onWishList;
        }

        private void BorrowButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (Book_Data data in Data_Context.onWishList)
            {
                User_Control.add_borrow_data(data.BID, Data_Context.currentUID, Date_picker.DisplayDate,
                    User_Control.retrieve_usertype(Data_Context.currentAccount.account_type).borrow_time);
            }
            //clear all books
            Data_Context.onWishList.Clear();
            ICart.ItemsSource = null;
            PopUpWindow popup = new PopUpWindow();
            popup.PopUpTB.Text = "Borrow data sent";
            popup.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Show();
        }

        private void Date_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BorrowButton.IsEnabled = true;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            List<Label> label_list = new List<Label>();
            Button btn = (Button)sender;
            Canvas cav = (Canvas)btn.Parent;
            foreach (Label lab in cav.Children.OfType<Label>())
            {
                label_list.Add(lab);
            }
            Book_Data book_focused = new Book_Data();
            if (label_list[0].Content != null)
                book_focused = User_Control.retrieve_book_data(label_list[0].Content.ToString());
            bool bcheck = false;
            List<Book_Data> book_list = new List<Book_Data>();
            foreach(Book_Data data in Data_Context.onWishList)
            {
                if (data.BID == book_focused.BID && !bcheck)
                {
                    bcheck = true;    
                    book_list.Add(data);
                } 
            }
            foreach(Book_Data data in book_list)
            {
                Data_Context.onWishList.Remove(data);
            }
            ICart.Items.Refresh();
        }
    }
}
