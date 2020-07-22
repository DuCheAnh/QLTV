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
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        bool[] array = new bool[3];


        public Window2()
        {
            InitializeComponent();
        }
        private void enable_signup_button()
        {
            bool bCheck = true;
            for (int i = 0; i < 3; i++)
            {
                if (array[i] == false) bCheck = false;
            }
            if (bCheck == true) Signup.IsEnabled = true;
            else Signup.IsEnabled = false;
        }
        private bool check_string_availability(string value)
        {
            if (value == "" || value.Trim() == "")
                return false;
            else return true;
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

        private async void Register(object sender, RoutedEventArgs e)
        {
            if (Password.Password == ConfirmPassword.Password)

            {
                if (RegisterIn.RegisterIn(Username.Text, Password.Password, Email.Text))
                {
                    MessageBox.Show("Đăng kí thành công");
                    this.Back(sender, e);
                }

            }
            else
            {
                MessageBox.Show("Confirm Password không trùng với Password");
            }

        }

        private void Email_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

        }


        private void Username_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(e.Text != null
       && e.Text.Length > 0
       && (char.IsLetterOrDigit(e.Text[0])));


        }

        private void Password_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
                }
                }
                
                
            APIInit.InitClient();

            if (await Account_data_Processor.Register(Username.Text, Password.Password, Email.Text))
            {
                MessageBox.Show("Dang ki thanh cong");
                this.Back(sender,e);
            }
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            array[0] = check_string_availability(Username.Text);
            enable_signup_button();
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            array[1] = check_string_availability(Password.Password);
            enable_signup_button();
        }

        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            array[2] = check_string_availability(ConfirmPassword.Password);
            enable_signup_button();
        }
    }
}
