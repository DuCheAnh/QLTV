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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUS_QuanLy;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BrwBookPage.xaml
    /// </summary>
    public partial class BrwBookPage : UserControl
    {
        User_Control_BUS user_control = new User_Control_BUS();
        public BrwBookPage()
        {
            InitializeComponent();
            init_book_page();
        }
        public void init_book_page()
        {
            this.NameTextBlock.Text = Data_Context.selected_book.name;
            this.AuthorTextBlock.Text = Data_Context.selected_book.author;
            this.ReleaseYearTextBlock.Text = "xuất bản " + Data_Context.selected_book.release_year.ToString();
            this.DescriptionTextBlock.Text = Data_Context.selected_book.description;
        }

        private void Lost_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void Extendbtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}