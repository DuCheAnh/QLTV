using BUS_QuanLy;
using DTO_QuanLy;
using MaterialDesignThemes.Wpf;
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
                User_Control.add_borrow_data(data.BID, Data_Context.currentUID, Date_picker.DisplayDate);
            }
            //clear all books
            Data_Context.onWishList.Clear();
            ICart.Items.Clear();
            PopUpWindow popup = new PopUpWindow();
            popup.PopUpTB.Text = "Borrow data sent";
            popup.Owner=Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Show();
        }

        private void Date_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BorrowButton.IsEnabled = true;
        }
    }
}
