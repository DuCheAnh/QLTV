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
using BUS_QuanLy;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        public MainPage()
        {
            InitializeComponent();
            if (Data_Context.currentHomePageBook.Count > 0)
                IBook.ItemsSource = Data_Context.currentHomePageBook;         
        }
      
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Book_Click(object sender, RoutedEventArgs e)
        {
            //variable to store newly found book
            List<Label> label_list = new List<Label>();
            Book_Data book_clicked =new Book_Data();
            Image img=new Image();
            //get the selected book
            Button btn = (Button)sender;
            Canvas canv = (Canvas)btn.Content;
            foreach (Label lab in canv.Children.OfType<Label>())
            {
                label_list.Add(lab);
            }
            book_clicked = admin_control.retrieve_book_data(label_list[0].Content.ToString());
            foreach (Image data in canv.Children.OfType<Image>())
            {
                img = data;
            }

                //init new book page
            BookPage book_page = new BookPage();
            book_page.NameTextBlock.Text = book_clicked.name;
            book_page.AuthorTextBlock.Text = book_clicked.author;
            book_page.AmountLeftTextBlock.Text = book_clicked.left.ToString() + " in stocks";
            book_page.ReleaseYearTextBlock.Text = "xuất bản " + book_clicked.release_year.ToString();
            book_page.DescriptionTextBlock.Text = book_clicked.description;
            book_page.BookImageBrush.ImageSource = img.Source;
            if (book_clicked.left < 1) book_page.BorrowButton.IsEnabled = false;
            bookList.Children.Clear();
            bookList.Children.Add(book_page);
        }
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
