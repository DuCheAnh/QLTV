using System.Windows.Controls;
using System.Windows.Data;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : UserControl
    {
        public BookPage()
        {
            InitializeComponent();
        }

        private void AmountLeftTextBlock_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            AmountLeftTextBlock.Text += " in stock";
        }
    }
}
