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
using DTO_QuanLy;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BorrowingBooks.xaml
    /// </summary>
    public partial class BorrowingBooks : UserControl
    {
        public BorrowingBooks(List<Book_Data> Books)
        {
            InitializeComponent();

            foreach(Book_Data book in Books)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = book.name;
                TreeViewBorrowingBooks.Items.Add(item);
            }
        }
    }
}
