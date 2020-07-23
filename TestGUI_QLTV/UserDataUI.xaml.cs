using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DTO_QuanLy;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for UserDataUI.xaml
    /// </summary>
    public partial class UserDataUI : UserControl
    {

        public UserDataUI()
        {
            InitializeComponent();
            init_datasource();
        }

        public async void init_datasource()
        { 
            UserDataListView.ItemsSource = await Account_data_Processor.all_accounts_data();
        }

        public async void Search_for(string sKey)
        {
            List<Account_Data> account_list = new List<Account_Data>();

            foreach(Account_Data data in await Account_data_Processor.all_accounts_data())
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

        private void UserControl_IsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            init_datasource();
        }

        private async void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.EditUserGUI editUserGUI = new TestGUI_QLTV.EditUserGUI();

            if(UserDataListView.SelectedItems.Count > 1)
            {
                foreach (Account_Data data in UserDataListView.SelectedItems) 
                {
                    await Account_data_Processor.Delete_account(data.UID);
                    /*admin_control.Delete_account(data.UID)*/;
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
    }
}
