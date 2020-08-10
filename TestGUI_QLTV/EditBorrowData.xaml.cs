using BUS_QuanLy;
using DTO_QuanLy;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for EditBorrowData.xaml
    /// </summary>
    public partial class EditBorrowData : Window
    {
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        User_Control_BUS user_control = new User_Control_BUS();
        Borrow_Data data = new Borrow_Data();
        public EditBorrowData()
        {
            InitializeComponent();
        }
        public void set_value_from_item(Borrow_Data selected_borrow_data)
        {
            data = selected_borrow_data;
            string uid, bid, borrowdate,username,bookname;
            username = UserNameTextBlock.Text+"null";
            bookname = BookNameTextBlock.Text+"null";
            uid = this.UIDTextBlock.Text + data.UID;
            if (user_control.Get_Single_UserInfo(data.UID) != null && admin_control.retrieve_book_data(data.BID) != null)
            {
                username = this.UserNameTextBlock.Text + user_control.Get_Single_UserInfo(data.UID).name;
                bookname = this.BookNameTextBlock.Text + admin_control.retrieve_book_data(data.BID).name;
            }
            bid = this.BIDTextBlock.Text + data.BID;
            borrowdate = BorrowDateTextBlock.Text + data.borrow_date.ToString();
            this.UIDTextBlock.Text = uid;
            this.UserNameTextBlock.Text = username;
            this.BIDTextBlock.Text = bid;
            this.BookNameTextBlock.Text = bookname;
            this.BorrowDateTextBlock.Text = borrowdate;
            if (data.packed == false)
                PackedButton.IsEnabled = true;
        }
        private void PackedButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            admin_control.delete_account_brid(data.UID, data.BrID);
            admin_control.delete_borrow(data.BrID);
            PopUpWindow popup = new PopUpWindow();
            popup.PopUpTB.Text = "Deleted";
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Owner = Window.GetWindow(this);
            popup.Closing += Popup_Closing;
            popup.Show();
        }

        private void Popup_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
            Window.GetWindow(this).Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
            Window.GetWindow(this).Owner.Focus();
        }
    }
}
