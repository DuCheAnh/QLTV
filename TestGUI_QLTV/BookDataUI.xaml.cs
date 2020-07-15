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
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BookDataUI.xaml
    /// </summary>
    public partial class BookDataUI : UserControl
    {
        public BookDataUI()
        {
            
            InitializeComponent();
            loadbooks();

        }

        private void btnAddBook(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.AddBookGUI addBookGUI = new TestGUI_QLTV.AddBookGUI();
            addBookGUI.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            addBookGUI.Show();
        }

        private async void loadbooks()
        {
            APIInit.InitClient();
            Data_Context.currentBooksdataUI = await Book_data_Processor.Get_all_books();
            lvBooksData.ItemsSource = Data_Context.currentBooksdataUI;
        }
    }
}
