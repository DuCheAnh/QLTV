using BUS_QuanLy;
using DTO_QuanLy;
using System.Windows;
using System.Windows.Controls;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for EditLibCardGUI.xaml
    /// </summary>
    public partial class EditLibCardGUI : Window
    {
        public LibCard_Data selected_libcard = new LibCard_Data();
        public EditLibCardGUI()
        {
            InitializeComponent();
        }
        bool[] bCheck = new bool[5];
        Admin_Control_BUS admin_control = new Admin_Control_BUS();

        public void set_value_from_item(LibCard_Data data)
        {
            this.selected_libcard = data;
            IDTextBox.Text = selected_libcard.identity_card;
            NameTextBox.Text = selected_libcard.name;
            DOBTextBox.Text = selected_libcard.DOB;
            for (int i = 0; i < this.AccountTypeComboBox.Items.Count; i++)
            {
                if (this.AccountTypeComboBox.Items[i].ToString().Contains(selected_libcard.account_type))
                {
                    this.AccountTypeComboBox.SelectedIndex = i;
                    bCheck[3] = true;
                    enable_addbutton();
                }
            }
            for (int i = 0; i < this.GenderComboBox.Items.Count; i++)
            {
                string sGender;
                if (selected_libcard.gender) sGender = "Male";
                else sGender = "Female";
                if (this.GenderComboBox.Items[i].ToString().Contains(sGender))
                {
                    this.GenderComboBox.SelectedIndex = i;
                    bCheck[4] = true;
                    enable_addbutton();
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            admin_control.delete_libcard(this.selected_libcard.LCID);
            bool bGender;
            if (GenderComboBox.SelectedItem.ToString().Contains("Male"))
                bGender = true;
            else bGender = false;
            if (admin_control.create_new_libcard(AccountTypeComboBox.Text, IDTextBox.Text,
                                   NameTextBox.Text, DOBTextBox.Text, bGender))
            {
                PopUpWindow popup = new PopUpWindow();
                Window.GetWindow(this).IsHitTestVisible = false;
                popup.Owner = Window.GetWindow(this);
                popup.PopUpTB.Text = "created";
                popup.Show();
            }
        }



        #region Closing action
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this.Owner).Focus();
            Window.GetWindow(this.Owner).IsHitTestVisible = true;
        }
        #endregion
        #region enable and disable the add button

        private void enable_addbutton()
        {
            bool all_filled = true;
            for (int i = 0; i < 5; i++)
            {
                if (bCheck[i] == false)
                    all_filled = false;
            }
            if (all_filled) EditButton.IsEnabled = true;
            else EditButton.IsEnabled = false;
        }
        private void DOBPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker dp = sender as DatePicker;
            DOBTextBox.Text = dp.Text;
        }

        private void IDTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (IDTextBox.Text.Trim() == "")
            {
                bCheck[0] = false;
            }
            else bCheck[0] = true;
            enable_addbutton();
        }

        private void NameTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Trim() == "")
            {
                bCheck[1] = false;
            }
            else bCheck[1] = true;
            enable_addbutton();
        }

        private void DOBTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DOBTextBox.Text.Trim() == "")
            {
                bCheck[2] = false;
            }
            else bCheck[2] = true;
            enable_addbutton();
        }


        private void AccountTypeComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AccountTypeComboBox.Text.Trim() == "")
            {
                bCheck[3] = false;
            }
            else bCheck[3] = true;
            enable_addbutton();
        }

        private void GenderComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GenderComboBox.Text.Trim() == "")
            {
                bCheck[4] = false;
            }
            else bCheck[4] = true;
            enable_addbutton();
        }



        #endregion

    }
}
