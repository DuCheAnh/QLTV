using BUS_QuanLy;
using DTO_QuanLy;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BorrowedHistoryUI.xaml
    /// </summary>
    public partial class BorrowedHistoryUI : UserControl
    {

        //variables
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        public BorrowedHistoryUI()
        {

            InitializeComponent();
            init_datasource("");
        }
        #region initiation
        public void init_datasource(string sKey)
        {
            List<Borrow_Data> borrow_list = new List<Borrow_Data>();
            foreach (Borrow_Data data in admin_control.retrieve_all_borrows())
            {
                if ((!string.IsNullOrEmpty(data.BrID) ? data.BrID.Contains(sKey) : false)
                    || (!string.IsNullOrEmpty(data.BrID) ? data.BID.Contains(sKey) : false)
                    || (!string.IsNullOrEmpty(data.BrID) ? data.UID.Contains(sKey) : false))
                    borrow_list.Add(data);
                else
                { }
            }
            BookDataListView.ItemsSource = borrow_list;
        }
        #endregion
        #region change selection and search
        private void BookDataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookDataListView.SelectedItems.Count > 0)
            {
                if (BookDataListView.SelectedItems.Count > 1)
                    EditBookButton.Content = "DELETE " + BookDataListView.SelectedItems.Count.ToString();
                else EditBookButton.Content = "EDIT";
                EditBookButton.IsEnabled = true;
            }
            else EditBookButton.IsEnabled = false;
        }


        private void ListViewSearchBar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                init_datasource(ListViewSearchBar.Text);
            }
        }
        #endregion

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            string td = "Danh sách Sách";
            System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            if ((bool)printDlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight);
                BookDataListView.Measure(pageSize);
                BookDataListView.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                printDlg.PrintVisual(BookDataListView, td);
            }
        }
    }
}
