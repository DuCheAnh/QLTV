using System.Windows;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for AddLibCardGUI.xaml
    /// </summary>
    public partial class AddLibCardGUI : Window
    {
        public AddLibCardGUI()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this.Owner).Focus();
            Window.GetWindow(this.Owner).IsHitTestVisible = true;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
