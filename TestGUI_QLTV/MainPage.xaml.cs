using BUS_QuanLy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        int current_page = 0;
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        public MainPage()
        {
            InitializeComponent();
            if (IBook.Items.Count > 0) IBook.Items.Clear();
            if (Data_Context.currentHomePageBook.Count > 0)
                IBook.ItemsSource = Data_Context.currentHomePageBook.Take(16);
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (Data_Context.currentHomePageBook.Count - 16 * (current_page + 1) > 0) current_page++;
            int nBookShown;
            if (Data_Context.currentHomePageBook.Count - (current_page + 1) * 16 >0) nBookShown = 16;
            else nBookShown = Data_Context.currentHomePageBook.Count - (current_page) * 16;
            IBook.ItemsSource = Data_Context.currentHomePageBook.GetRange(current_page * 16, nBookShown);
            PageNumberTextBlock.Text = (current_page + 1).ToString();
        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (current_page > 0) current_page--;
            IBook.ItemsSource = Data_Context.currentHomePageBook.GetRange(current_page * 16, 16);
            PageNumberTextBlock.Text = (current_page + 1).ToString();

        }

        public void Book_Click(object sender, RoutedEventArgs e)
        {

            //variable to store newly found book
            List<Label> label_list = new List<Label>();
            Image img = new Image();
            //get the selected book
            Button btn = (Button)sender;
            Canvas canv = (Canvas)btn.Content;
            foreach (Label lab in canv.Children.OfType<Label>())
            {
                label_list.Add(lab);
            }
            Data_Context.selected_book = admin_control.retrieve_book_data(label_list[0].Content.ToString());
            foreach (Image data in canv.Children.OfType<Image>())
            {
                img = data;
            }

            //init new book page
            BookPage book_page = new BookPage();
            book_page.BookImageBrush.ImageSource = img.Source;
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
            bi.DecodePixelWidth = 270;
            bi.DecodePixelHeight = 360;
            bi.EndInit();


            return bi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
