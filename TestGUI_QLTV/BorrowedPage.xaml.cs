using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using BUS_QuanLy;
using DTO_QuanLy;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BorrowedPage.xaml
    /// </summary>
    public partial class BorrowedPage : Window
    {
        List<Book_Data> brwedbook = new List<Book_Data>();
        User_Control_BUS User_Control = new User_Control_BUS();
        public BorrowedPage()
        {
            InitializeComponent();
            List<string> BrID_List= Data_Context.currentAccount.BrID;
            foreach(string Data in BrID_List)
            {
                Borrow_Data Brwdata = User_Control.retrieve_borrow_data(Data);
                brwedbook.Add(User_Control.retrieve_book_data(Brwdata.BID));
                Console.WriteLine(Brwdata.BID);
            }
            if (brwedbook.Count > 0)
                IBook.ItemsSource = brwedbook;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Borrowed_Click(object sender, RoutedEventArgs e)
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
            foreach (Image data in canv.Children.OfType<Image>())
            {
                img = data;
            }

            //init new book page
            BrwBookPage brwbook_page = new BrwBookPage();
            brwbook_page.BookImageBrush.ImageSource = img.Source;
            borrowedList.Children.Clear();
            borrowedList.Children.Add(brwbook_page);
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
}
