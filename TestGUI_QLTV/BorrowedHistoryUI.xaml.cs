using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DTO_QuanLy;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BorrowedHistoryUI.xaml
    /// </summary>
    public partial class BorrowedHistoryUI : UserControl
    {
      
        public BorrowedHistoryUI()
        {

            InitializeComponent();
            init_datasource("");
        }
        public async void init_datasource(string sKey)
        {
            List<Borrow_Data> borrow_list = new List<Borrow_Data>();
            foreach (Borrow_Data data in await Borrow_data_Processor.retrieve_all_borrows())
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

        private void UserControl_IsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            init_datasource("");

        }


        private void ListViewSearchBar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                init_datasource(ListViewSearchBar.Text);
            }
        }
    }
}
