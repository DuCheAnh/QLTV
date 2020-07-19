using System.Collections.Generic;
using System.Windows;

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
