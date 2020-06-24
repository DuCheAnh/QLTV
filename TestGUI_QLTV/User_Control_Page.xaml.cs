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
using TestGUI_QLTV;

namespace GUI_QuanLy
{
    /// <summary>
    /// Interaction logic for User_Control_Page.xaml
    /// </summary>
    public partial class User_Control_Page : UserControl
    {
        string sUID = "1";
        Account_Data tempdata = new Account_Data();
        User_Control_BUS User_BUS = new User_Control_BUS();

        public User_Control_Page()
        {
            
            //Account_Data tempdata = await Account_data_Processor.LoadAccount();
            InitializeComponent();
            APIInit.InitClient();

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
