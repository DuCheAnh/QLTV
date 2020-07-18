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
using DTO_QuanLy;
using BUS_QuanLy;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for ChangeEmail.xaml
    /// </summary>
    public partial class ChangeEmail : Window
    {
        User_Control_BUS BUS_method = new User_Control_BUS();
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
            BUS_method.change_user_Email(Data_Context.currentUID, New_email_txb.Text);
            Window.GetWindow(this).Hide();
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
        }
    }
}