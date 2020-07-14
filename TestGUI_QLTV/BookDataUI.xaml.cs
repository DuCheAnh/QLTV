using BUS_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO_QuanLy;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BookDataUI.xaml
    /// </summary>
    public partial class BookDataUI : UserControl
    {
      
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        public BookDataUI()
        {
            
            InitializeComponent();
            init_datasource();
        }
        public void init_datasource()
        {
            BookDataListView.ItemsSource = admin_control.all_books_data();
        }
        private void btnAddBook(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.AddBookGUI addBookGUI = new TestGUI_QLTV.AddBookGUI();
            addBookGUI.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            addBookGUI.Show();
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.EditBookGUI editBookGUI = new TestGUI_QLTV.EditBookGUI();
            editBookGUI.set_value_from_item((Book_Data)BookDataListView.SelectedItems[0]);
            editBookGUI.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            editBookGUI.Show();
        }

        private void BookDataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookDataListView.SelectedItems.Count > 0)
            {
                EditBookButton.IsEnabled = true;
            }
            else EditBookButton.IsEnabled = false;
        }
    }
}
