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

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BorrowedPage.xaml
    /// </summary>
    public partial class BorrowedPage : Window
    {
        public BorrowedPage()
        {
            InitializeComponent();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            //this.OnDeactivated(e);
            //Owner.Topmost = true;
            this.Close();
            //Owner.Topmost = false;
            //Owner.Focus();
        }
    }
}
