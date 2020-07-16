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
            Account_data_Processor.PUT_change_email(Data_Context.currentUID, New_email_txb.Text);
            this.Close();

        }
    }
}