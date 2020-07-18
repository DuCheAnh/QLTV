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
using BUS_QuanLy;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        bool MatchCheck = false;
        User_Control_BUS BUS_method = new User_Control_BUS();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (MatchCheck)
            {
                BUS_method.change_user_password(Data_Context.currentUID, New_password_Txb.Text);
                Data_Context.currentAccount.password = New_password_Txb.Text;
            }

            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
            Window.GetWindow(this).Close();
        }

        private void Check(object sender, RoutedEventArgs e)
        {
            if (BUS_method.Checking(Data_Context.currentUID, Old_password_txb.Text))
            {
                MessageBox.Show("Match!");
                MatchCheck = true;
            }
            else
                MessageBox.Show("WrongPassword");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;

            this.Owner.DataContext = Data_Context.currentAccount;
        }
    }
}
