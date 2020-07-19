using System.Windows;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window
    {

        public PopUpWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }


    }
}
