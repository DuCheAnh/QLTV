using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
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
using BUS_QuanLy;
using DTO_QuanLy;
using TestGUI_QLTV;
using TestGUI_QLTV.Processor;

namespace GUI_QuanLy
{
    /// <summary>
    /// Interaction logic for User_Control_Page.xaml
    /// </summary>
    public partial class User_Control_Page : UserControl
    {

        string sUID = "2";
        Account_Data tempdata = new Account_Data();
        User_Control_BUS User_BUS = new User_Control_BUS();

        public User_Control_Page()
        {
            
            //Account_Data tempdata = await Account_data_Processor.LoadAccount();
            InitializeComponent();
            APIInit.InitClient();

            var Books = new List<Book_Data>();
            Books.Add(new Book_Data("1", "One Hundred Years of Solitude", "Gabriel Marquez", new DateTime(2000,2,28), "Philosophy", "nothing much i just loved it", "NULL but by string", 1, 1, "me", "no"));

            BorrowingBooks.Children.Add(new BorrowingBooks(Books));
        }

        private async Task binding_user()
        {
            tempdata = await Account_data_Processor.GetAccount(sUID);
            this.DataContext = tempdata;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await binding_user();
        }
    }



    public class BooltoGenderConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return "Male";
                else
                    return "Female";
            }
            return "Female";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "male":
                    return true;
                case "female":
                    return false;
            }
            return false;
        }
    }
}
