using System;
using System.Collections.Generic;
using System.Globalization;
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
using BUS_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    /// <summary>
    /// Interaction logic for User_Control_Page.xaml
    /// </summary>
    public partial class User_Control_Page : UserControl
    {
        string sUID = "U637293424189421998";
        User_Control_BUS User_BUS = new User_Control_BUS();

        public User_Control_Page()
        {
            Account_Data tempdata = User_BUS.Get_Single_UserInfo(sUID);
            PasswordBox passwordBox = new PasswordBox();
            passwordBox.IsEnabled = false;
            this.DataContext = tempdata;
            InitializeComponent();
        }

        private void Borrowed_Book(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.BorrowedPage borrowedPage = new TestGUI_QLTV.BorrowedPage();
            borrowedPage.Owner = Window.GetWindow(this);
            borrowedPage.Show();
        }

        private void Change_Email(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.ChangeEmail changeEmail = new TestGUI_QLTV.ChangeEmail();
            changeEmail.Owner = Window.GetWindow(this);
            changeEmail.Show();
        }

        private void Change_Password(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.ChangePassword changePassword = new TestGUI_QLTV.ChangePassword();
            changePassword.Owner = Window.GetWindow(this);
            changePassword.Show();
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.IsReadOnly = false;
            //textBox.CaretIndex = textBox.Text.Count();
            textBox.Select(50, 50);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.IsReadOnly = true;
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
