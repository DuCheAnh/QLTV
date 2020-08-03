using BUS_QuanLy;
using DTO_QuanLy;
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
        }

        private void Date_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            BorrowButton.IsEnabled = true;
        }
    }
}
