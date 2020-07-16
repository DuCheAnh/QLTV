using DTO_QuanLy;
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
using System.IO;

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
            if (Data_Context.currentHomePageBook.Count > 0)
                IBook.ItemsSource = Data_Context.currentHomePageBook;
            /*
            foreach (Book_Data item in IBook.Items)
            {
                byte[] binaryData = Convert.FromBase64String(item.cover_page);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();
                
                //Pic.Source = bi;
            }*/
        }
       



        /*        private List<Products> GetProducts()
                {
                    return new List<Products>()
                    {
                        new Products("Chiken with a knife 1", "a.png" ,"1"),
                        new Products("Chiken with a knife 2", "a.png" ,"2"),
                        new Products("Chiken with a knife 3", "a.png" ,"bhuch"),
                        new Products("Chiken with a knife 4", "a.png" ,"dhuch"),
                        new Products("Chiken with a knife 5", "a.png" ,"ehuch"),
                        new Products("Chiken with a knife 1", "a.png" ,"chuch"),
                        new Products("Chiken with a knife 2", "a.png" ,"ahuch"),
                        new Products("Chiken with a knife 3", "a.png" ,"bhuch"),
                        new Products("Chiken with a knife 4", "a.png" ,"dhuch"),
                        new Products("Chiken with a knife 5", "a.png" ,"ehuch"),

                    };
                }*/
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


/*
            ListBoxItem myListBoxItem = (ListBoxItem)(IBook.ItemContainerGenerator.ContainerFromItem(IBook.Items.CurrentItem));

            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);

            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;

            Label myTextBlock = (Label)myDataTemplate.FindName("Actor", myContentPresenter);

            MessageBox.Show("The text of the TextBlock of the selected list item: " + myTextBlock.Content);*/
        }

  

 /*       private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }*/
    }
    public class Base64ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = value as string;

            if (s == null)
                return null;

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(System.Convert.FromBase64String(s));
            bi.EndInit();

            return bi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
