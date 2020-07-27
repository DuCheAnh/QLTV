using BUS_QuanLy;
using System.Windows;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for RedeemLibCardWindow.xaml
    /// </summary>
    public partial class RedeemLibCardWindow : Window
    {
        User_Control_BUS user_control = new User_Control_BUS();

        public RedeemLibCardWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            set_libcard(LibCardTextBox.Text);
        }
        private void set_libcard(string sLibCardID)
        {
            if (sLibCardID.Trim() != null)
            {
                if (user_control.Search_for_LCID(sLibCardID) != null)
                {
                    if (user_control.set_libcard_to_user(sLibCardID, Data_Context.currentUID))
                        open_popup("Succeeded");
                    else open_popup("Libcard already used");
                }
                else open_popup("Libcard not found");
            }
            else
                open_popup("Can't be null");
        }
        private void open_popup(string message)
        {
            PopUpWindow popup = new PopUpWindow();
            popup.PopUpTB.Text = message;
            Window.GetWindow(this.Owner).IsHitTestVisible = false;
            popup.Owner = Window.GetWindow(this.Owner);
            popup.Show();
            Window.GetWindow(this).Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

    }
}
