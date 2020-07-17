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
            Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (MatchCheck)
            {
                Account_data_Processor.PUT_change_password(Data_Context.currentUID, New_password_Txb.Text);
            }
            Window.GetWindow(this).Hide();
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
    }
}
