using System.Windows;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for ChangeEmail.xaml
    /// </summary>
    public partial class ChangeEmail : Window
    {
        public ChangeEmail()
        {
            InitializeComponent();

        }

        private void Close(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            //BUS_method.change_user_Email(Data_Context.currentUID, New_email_txb.Text);
            Window.GetWindow(this).Hide();
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
            Account_data_Processor.PUT_change_email(Data_Context.currentUID, New_email_txb.Text);
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
        }
    }
}