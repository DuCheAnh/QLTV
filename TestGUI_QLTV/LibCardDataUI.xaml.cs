using BUS_QuanLy;
using DTO_QuanLy;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for LibCardDataUI.xaml
    /// </summary>
    public partial class LibCardDataUI : UserControl
    {
        Admin_Control_BUS admin_control = new Admin_Control_BUS();

        public LibCardDataUI()
        {
            InitializeComponent();
            init_datasource("");
        }

        private void init_datasource(string key)
        {
            List<LibCard_Data> libcard_list = new List<LibCard_Data>();
            foreach (LibCard_Data data in admin_control.all_libcard_data())
            {
                if (data.name.Contains(key) || data.LCID.Contains(key) || data.identity_card.Contains(key))
                {
                    libcard_list.Add(data);
                }
            }
            LibCardListView.ItemsSource = libcard_list;
        }



        private void AddLibCardButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TestGUI_QLTV.AddLibCardGUI add_libcard_gui = new TestGUI_QLTV.AddLibCardGUI();
            add_libcard_gui.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            add_libcard_gui.Show();
        }

        private void LibCardListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LibCardListView.SelectedItems.Count > 0)
            {
                if (LibCardListView.SelectedItems.Count > 1)
                    EditLibCardButton.Content = "DELETE " + LibCardListView.SelectedItems.Count.ToString();
                else EditLibCardButton.Content = "EDIT";
                EditLibCardButton.IsEnabled = true;
            }
            else EditLibCardButton.IsEnabled = false;
        }

        private void EditLibCardButton_Click(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.EditLibCardGUI edit_libcard_gui = new TestGUI_QLTV.EditLibCardGUI();
            edit_libcard_gui.set_value_from_item(LibCardListView.SelectedItems[0] as LibCard_Data);
            edit_libcard_gui.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            edit_libcard_gui.Show();
        }
    }
}
