using BUS_QuanLy;
using DTO_QuanLy;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for EditMultipleBorrow.xaml
    /// </summary>
    public partial class EditMultipleBorrow : Window
    {
        List<Borrow_Data> borrow_list = new List<Borrow_Data>();
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        public EditMultipleBorrow()
        {
            InitializeComponent();
        }
        public void set_data_up(int selected_amount, List<Borrow_Data> external_borrow_list)
        {
            DeleteButton.Content += " " + selected_amount.ToString();
            borrow_list = external_borrow_list;
            PackedButton.Content += " " + borrow_list.Where(x => x.packed == false).ToList().Count.ToString();

            if (borrow_list.Where(x => x.packed == false).ToList().Count > 0)
            {
                PackedButton.IsEnabled = true;
            }
        }

        private void PackedButton_Click(object sender, RoutedEventArgs e)
        {
            int count = borrow_list.Where(x => x.packed == false).ToList().Count;
            foreach (Borrow_Data data in borrow_list)
            {
                admin_control.update_packed_to(true, data);
            }
            if ( count> 0)
            {

                popup_message("Packed " + count.ToString());
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Borrow_Data data in borrow_list)
            {
                admin_control.delete_account_brid(data.UID, data.BrID);
                admin_control.delete_borrow(data.BrID);
            }
            popup_message("Deleted " + borrow_list.Count);
        }
        void popup_message(string sMessage)
        {
            PopUpWindow popup = new PopUpWindow();
            popup.PopUpTB.Text = sMessage;
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Owner = Window.GetWindow(this);
            popup.Closing += Popup_Closing;
            popup.Show();
        }
        private void Popup_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
