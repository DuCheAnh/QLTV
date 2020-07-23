using DTO_QuanLy;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for LibCardDataUI.xaml
    /// </summary>
    public partial class LibCardDataUI : UserControl
    {

        public LibCardDataUI()
        {
            InitializeComponent();
            init_datasource("");
        }
        private async void init_datasource(string key)
        {
            List<LibCard_Data> libcard_list = new List<LibCard_Data>();
            foreach (LibCard_Data data in await LibCard_data_Processor.Get_all_libcard_data() /*admin_control.all_libcard_data()*/)
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
