using BUS_QuanLy;
using DTO_QuanLy;
using System.Collections.Generic;
using System.Linq;
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
        List<Borrow_Data> borrow_list = new List<Borrow_Data>();
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        public BorrowedHistoryUI()
        {

            InitializeComponent();
            init_datasource("");
        }
        #region initiation
        public void init_datasource(string sKey)
        {
            borrow_list = new List<Borrow_Data>();
            foreach (Borrow_Data data in admin_control.retrieve_all_borrows())
            {
                if ((!string.IsNullOrEmpty(data.BrID) ? data.BrID.Contains(sKey) : false)
                    || (!string.IsNullOrEmpty(data.BrID) ? data.BID.Contains(sKey) : false)
                    || (!string.IsNullOrEmpty(data.BrID) ? data.UID.Contains(sKey) : false))
                    borrow_list.Add(data);
                else
                { }
            }
            borrow_list = borrow_list.OrderBy(x => x.packed).ToList();
            BookDataListView.ItemsSource = borrow_list;
        }
        #endregion
        #region change selection and search
        private void BookDataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookDataListView.SelectedItems.Count > 0)
            {
                AddBorrowButton.IsEnabled = true;
                AddBorrowButton.Content = "RETURNED " + BookDataListView.SelectedItems.Count.ToString();
                if (BookDataListView.SelectedItems.Count > 1)
                    EditBorrowButton.Content = "EDIT " + BookDataListView.SelectedItems.Count.ToString();
                else EditBorrowButton.Content = "EDIT";
                EditBorrowButton.IsEnabled = true;
            }
            else EditBorrowButton.IsEnabled = false;
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

        private void EditBorrowButton_Click(object sender, RoutedEventArgs e)
        {

            Window.GetWindow(this).IsHitTestVisible = false;
            if (BookDataListView.SelectedItems.Count == 1)
            {
                EditBorrowData borrowdata_popup = new EditBorrowData();
                borrowdata_popup.Owner = Window.GetWindow(this);
                borrowdata_popup.set_value_from_item((Borrow_Data)BookDataListView.SelectedItems[0]);
                borrowdata_popup.Show();
            }
            else if (BookDataListView.SelectedItems.Count > 1)
            {
                EditMultipleBorrow multipleborrows_popup = new EditMultipleBorrow();
                multipleborrows_popup.Owner = Window.GetWindow(this);
                multipleborrows_popup.set_data_up(BookDataListView.SelectedItems.Count, BookDataListView.SelectedItems.Cast<Borrow_Data>().ToList());
                multipleborrows_popup.Show();
            }
        }

        private void AddBorrowButton_Click(object sender, RoutedEventArgs e)
        {
            List<Borrow_Data> borrowl = BookDataListView.SelectedItems.Cast<Borrow_Data>().ToList();
            foreach (Borrow_Data data in borrowl)
                admin_control.update_returned_to(true, data);
            BookDataListView.Items.Refresh();
            init_datasource("");
        }
    }
}
