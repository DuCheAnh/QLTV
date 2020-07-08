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
using System.Windows.Shapes;
using DTO_QuanLy;
using BUS_QuanLy;
using MaterialDesignThemes.Wpf;

namespace TestGUI_QLTV
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Login Bus_method = new Login();
        public Window1()
        {
            InitializeComponent();

        }
        private void TextBox_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception mes)
            {
                MessageBox.Show(mes.Message);
            }
        }

        private void OpenForm(object sender, RoutedEventArgs e)
        {
            Window2 Rg = new Window2();
            Rg.Show();
            this.Hide();
        }

        private void OpenMain(object sender, RoutedEventArgs e)
        {
            if(Bus_method.LoginMethod(Username.Text, Password.Password))
            {
                User_Control_BUS UserData = new User_Control_BUS();
                Data_Context.currentAccount = UserData.search_for_account(Username.Text);
                Data_Context.currentUID = UserData.search_for_account(Username.Text).UID;
                MainWindow mn = new MainWindow();
                mn.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("sai tai khoan hoac khong co");
            }
            
        }

       
    }
  
    
}
