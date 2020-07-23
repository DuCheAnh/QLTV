using System.Windows;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        bool MatchCheck = false;

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
                Account_data_Processor.PUT_change_password(Data_Context.currentUID, New_password_Txb.Text);
            }

            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
            Window.GetWindow(this).Close();
        }

        private async void Check(object sender, RoutedEventArgs e)
        {
            if (await Account_data_Processor.Check_current_password(Data_Context.currentUID, Old_password_txb.Text)) 
            {
                MessageBox.Show("Match!");
                MatchCheck = true;
            }
            else
                MessageBox.Show("WrongPassword, try again!");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;

            this.Owner.DataContext = Data_Context.currentAccount;
        }
    }
}
