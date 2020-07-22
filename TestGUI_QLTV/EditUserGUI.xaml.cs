using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO_QuanLy;
using BUS_QuanLy;
using System.IO;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for EditUserGUI.xaml
    /// </summary>
    public partial class EditUserGUI : Window
    {
        string oldLCID;
        bool[] array = new bool[3];
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        Account_Data selected_Account;
        string img = null;

        public EditUserGUI()
        {
            InitializeComponent();
        }

        public void set_value(Account_Data data)
        {
            selected_Account = data;

            set_libcard_combobox();

            UserAccount_txb.Text = selected_Account.account;
            UserMail_txb.Text = selected_Account.email;
            PasswordBox.Text = selected_Account.password;

            if (selected_Account.LCID != null)
            {
                oldLCID = selected_Account.LCID;
                for (int i = 0; i < this.libcardCombobox.Items.Count; i++)
                {
                    if (!string.IsNullOrEmpty(((ComboBoxItem)libcardCombobox.Items[i]).Tag.ToString()) ? (((ComboBoxItem)libcardCombobox.Items[i]).Tag.ToString().Contains(selected_Account.LCID)) : false)
                    {
                        libcardCombobox.SelectedIndex = i;
                    }
                }
            }
            #region set profile picture
            /*            byte[] binaryData = Convert.FromBase64String(selected_Account.profile_picture);

                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = new MemoryStream(binaryData);
                        bi.EndInit();
                        Profile_picture.Source = bi;*/
            #endregion
        }



        private void set_libcard_combobox()
        {
            List<LibCard_Data> libcards = admin_control.Get_all_unused_libcard(selected_Account.UID);

            foreach (LibCard_Data libcard in libcards)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = libcard.name;
                item.Tag = libcard.LCID;
                libcardCombobox.Items.Add(item);
            }

        }

        #region delete click
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            admin_control.Delete_account(selected_Account.UID);

            TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
            popup.PopUpTB.Text = "Deleted";
            popup.Owner = Window.GetWindow(this.Owner);
            this.Close();
            Window.GetWindow(this.Owner).IsHitTestVisible = false;
            popup.Show();
        }
        #endregion

        #region Edit click
        private void Edit_user(object sender, RoutedEventArgs e)
        {
            Account_Data data = selected_Account;
            data.account = UserAccount_txb.Text;
            data.password = PasswordBox.Text;
            data.email = UserMail_txb.Text;
            data.LCID = ((ComboBoxItem)libcardCombobox.SelectedItem).Tag.ToString();

            admin_control.Update_User_data(data);

            if (!string.IsNullOrEmpty(oldLCID))
            {
                LibCard_Data oldlibcard = admin_control.Retrive_libcard_data(oldLCID);
                oldlibcard.used = false;
                admin_control.update_libcard_useable(oldlibcard, oldlibcard.used);
            }
            if (!string.IsNullOrEmpty(data.LCID))
            {
                LibCard_Data newlibcard = admin_control.Retrive_libcard_data(data.LCID);
                newlibcard.used = true;
                admin_control.update_libcard_useable(newlibcard, newlibcard.used);
            }

            TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
            popup.PopUpTB.Text = "Updated";
            popup.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Show();
        }
        #endregion

        //set owner click able
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
        }

        #region profile picture
        private void Change_profile_picture(object sender, RoutedEventArgs e)
        {

        }
        #endregion


        #region Enable and disable button base on input

        private void enable_Edit_button()
        {
            bool check = true;

            if (array.Any(b => b == false))
            {
                check = false;
            }

            if (check == true)
                Edit_btn.IsEnabled = true;
            else
                Edit_btn.IsEnabled = false;
        }

        private bool check_string_avalability(string value)
        {
            if (string.IsNullOrEmpty(value.Trim()))
                return false;
            else return true;
        }

        private void UserAccount_txb_TextChanged(object sender, TextChangedEventArgs e)
        {
            array[0] = check_string_avalability(UserAccount_txb.Text);
            enable_Edit_button();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            array[1] = check_string_avalability(PasswordBox.Text);
            enable_Edit_button();
        }

        private void UserMail_txb_TextChanged(object sender, TextChangedEventArgs e)
        {
            array[2] = check_string_avalability(UserMail_txb.Text);
            enable_Edit_button();
        }

        #endregion

    }
}