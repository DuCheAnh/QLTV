using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using TestGUI_QLTV.Processor;

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
            if (Data_Context.currentBooksdataUI != null)
                IBook.ItemsSource = Data_Context.currentBooksdataUI;
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPreviousPage_Click(object sender, RoutedEventArgs e)
        {

        }

        public async void Book_Click(object sender, RoutedEventArgs e)
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

            Data_Context.selected_book = await Book_data_Processor.retrieve_book_data(label_list[0].Content.ToString());
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
            bi.EndInit();

            return bi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
