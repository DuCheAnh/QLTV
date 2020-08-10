using BUS_QuanLy;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        bool[] array = new bool[3];
        bool succeeded = false;
        bool turningback = false;
        User_Control_BUS user_control = new User_Control_BUS();
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
            turningback = true;
            Window1 Rg = new Window1();
            Rg.Show();
            this.Close();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            if (!(Password.Password.Length < 8 || Username.Text.Length < 8))
            {
                if (Password.Password == ConfirmPassword.Password)
                {
                    if (user_control.search_for_account(Username.Text) == null)
                    {
                        if (user_control.RegisterIn(Username.Text, Password.Password, Email.Text))
                        {
                            MessageBox.Show("Đăng kí thành công");
                            succeeded = true;
                            this.Back(sender, e);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Trùng tài khoản");
                    }
                }
                else
                {
                    MessageBox.Show("xác nhận mật khẩu sai");
                }
            }
            else
            {
                MessageBox.Show("mk va tk phai dai hon 8 ky tu");
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!succeeded && !turningback)
                Environment.Exit(Environment.ExitCode);
        }
    }
}
