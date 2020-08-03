using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TestGUI_QLTV
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private User_Control_BUS user_control = new User_Control_BUS();
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
                Environment.Exit(Environment.ExitCode);
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
            this.Close();
        }

        private void OpenMain(object sender, RoutedEventArgs e)
        {
            Account_Data user = user_control.search_for_account(Username.Text);

            if (user!=null && user.password==Password.Password)
            {
                Data_Context.currentAccount = user;
                Data_Context.currentUID = user.UID;
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
