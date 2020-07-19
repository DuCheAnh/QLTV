using BUS_QuanLy;
using System;
using System.Windows;
using System.Windows.Input;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Register Bus_register = new Register();
        public Window2()
        {
            InitializeComponent();
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

        private void Back(object sender, RoutedEventArgs e)
        {
            Window1 Rg = new Window1();
            Rg.Show();
            this.Close();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            if (Bus_register.RegisterIn(Username.Text, Password.Password, Email.Text))
            {
                MessageBox.Show("Dang ki thanh cong");
                this.Back(sender, e);

            }

        }
    }
}
