using System;
using System.Linq;
using System.Windows.Controls;

namespace TestGUI_QLTV
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void TreeViewItem_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TreeViewItem treeitem = sender as TreeViewItem;
            Console.WriteLine(treeitem.Header.ToString());
            Data_Context.currentHomePageBook = Data_Context.currentHomePageBook.Where(x => x.category.Contains(treeitem.Header.ToString())).ToList();
        }
    }
}
