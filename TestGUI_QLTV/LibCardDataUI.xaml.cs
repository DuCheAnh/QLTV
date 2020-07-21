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
    }
}
