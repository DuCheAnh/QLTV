using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BorrowedPage.xaml
    /// </summary>
    public partial class BorrowedPage : Window
    {
        public BorrowedPage()
        {
            InitializeComponent();
            var product = GetProducts();
            if (product.Count > 0)
                IBook.ItemsSource = product;
        }

        private List<Products> GetProducts()
        {
            return new List<Products>()
            {
                new Products("Chiken with a knife 1", "a.png" ,"chuch"),
                new Products("Chiken with a knife 2", "a.png" ,"ahuch"),
                new Products("Chiken with a knife 3", "a.png" ,"bhuch"),
                new Products("Chiken with a knife 4", "a.png" ,"dhuch"),
                new Products("Chiken with a knife 5", "a.png" ,"ehuch"),
                new Products("Chiken with a knife 1", "a.png" ,"chuch"),
                new Products("Chiken with a knife 2", "a.png" ,"ahuch"),
                new Products("Chiken with a knife 3", "a.png" ,"bhuch"),
                new Products("Chiken with a knife 4", "a.png" ,"dhuch"),

            };
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("cacc");
        }
    }
}
