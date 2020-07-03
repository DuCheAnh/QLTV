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

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
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
                new Products("Chiken with a knife 5", "a.png" ,"ehuch"),
                
            };
        }
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("cacc");
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
