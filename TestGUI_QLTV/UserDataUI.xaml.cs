using BUS_QuanLy;
using DTO_QuanLy;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for UserDataUI.xaml
    /// </summary>
    public partial class UserDataUI : UserControl
    {
        Admin_Control_BUS admin_control = new Admin_Control_BUS();

        public UserDataUI()
        {
            InitializeComponent();
            init_datasource();
        }

        public void init_datasource()
        {
            UserDataListView.ItemsSource = admin_control.all_accounts_data();
        }

        public void Search_for(string sKey)
        {
            List<Account_Data> account_list = new List<Account_Data>();

            foreach (Account_Data data in admin_control.all_accounts_data())
            {
                if ((!string.IsNullOrEmpty(data.email) ? data.email.Contains(sKey) : false)
                    || (!string.IsNullOrEmpty(data.account) ? data.account.Contains(sKey) : false)
                    || (!string.IsNullOrEmpty(data.name) ? data.name.Contains(sKey) : false)
                    || (!string.IsNullOrEmpty(data.account_type) ? data.account_type.Contains(sKey) : false))
                    account_list.Add(data);
                else
                { }
            }
            UserDataListView.ItemsSource = account_list;
        }


        private void UserDataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserDataListView.SelectedItems.Count > 0)
            {
                if (UserDataListView.SelectedItems.Count > 1)
                    EditUserbtn.Content = "DELETE " + UserDataListView.SelectedItems.Count.ToString();
                else EditUserbtn.Content = "EDIT";
                EditUserbtn.IsEnabled = true;
            }
            else EditUserbtn.IsEnabled = false;
        }

        

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.EditUserGUI editUserGUI = new TestGUI_QLTV.EditUserGUI();

            if (UserDataListView.SelectedItems.Count > 1)
            {
                foreach (Account_Data data in UserDataListView.SelectedItems)
                {
                    admin_control.Delete_account(data.UID);
                }

                TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
                popup.PopUpTB.Text = "Deleted";
                popup.Owner = Window.GetWindow(this);
                Window.GetWindow(this).IsHitTestVisible = false;
                popup.Show();
            }
            else
            {
                editUserGUI.set_value((Account_Data)UserDataListView.SelectedItem);
                editUserGUI.Owner = Window.GetWindow(this);
                Window.GetWindow(this).IsHitTestVisible = false;
                editUserGUI.Show();
            }
        }

        private void ListViewSearchBar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrEmpty(ListViewSearchBar.Text))
                    init_datasource();
                else
                    Search_for(ListViewSearchBar.Text);
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            string td = "Danh sách Sách";
            System.Windows.Controls.PrintDialog printDlg = new System.Windows.Controls.PrintDialog();
            if ((bool)printDlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight);
                UserDataListView.Measure(pageSize);
                UserDataListView.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                printDlg.PrintVisual(UserDataListView, td);
            }
        }

    }
}
