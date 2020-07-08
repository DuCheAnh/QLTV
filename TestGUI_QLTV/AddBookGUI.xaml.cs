using BUS_QuanLy;
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
    /// Interaction logic for AddBookGUI.xaml
    /// </summary>
    public partial class AddBookGUI : Window
    {
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        public AddBookGUI()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            admin_control.add_new_book(tbName.Text, tbAuthor.Text, DateTime.Today, cbCategory.Text, tbDescription.Text, "", 1, Convert.ToInt32(tbAmount.Text));
            TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
            popup.PopUpTB.Text = "Added a new book";
            popup.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
        }
    }
}
