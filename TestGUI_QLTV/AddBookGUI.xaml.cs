using BUS_QuanLy;
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
using System.Text.RegularExpressions;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for AddBookGUI.xaml
    /// </summary>
    public partial class AddBookGUI : Window
    {
        bool[] array=new bool[7];
        int count = -1;
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        public AddBookGUI()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            admin_control.add_new_book(NameTextBox.Text, AuthorTextBox.Text, Convert.ToInt32(ReleaseDateTextBox.Text), 
                CategoryComboBox.Text, DescTextBox.Text,""/*cover page*/, Convert.ToInt32(PriceTextBox.Text), Convert.ToInt32(AmountTextBox.Text));
            //create a new popup window to notify success
            TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
            popup.PopUpTB.Text = "Added a new book";
            popup.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Show();
        }


        //allow it's owner to be clickable
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.Focus();
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
        }



        #region only accept number input {AmountTextBox,ReleaseDateTextBox,PriceTextBox}
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion


        #region Enable and disable add button base on input

       
        private void enable_add_button()
        {         
                bool bCheck = true;
                for (int i = 0; i < 7;i++)
                {
                    if (array[i] == false) bCheck = false;
                }
            if (bCheck == true) AddButton.IsEnabled = true;
            else AddButton.IsEnabled = false;
        }
        private bool check_string_availability(string value)
        {
            if (value == "" || value.Trim() == "")
                return false;
            else return true;
        }

        private void NameTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            array[0] = check_string_availability(NameTextBox.Text);
            enable_add_button();
        }

        private void AuthorTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            array[1] = check_string_availability(AuthorTextBox.Text);
            enable_add_button();
        }

        private void ReleaseDateTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            array[2] = check_string_availability(ReleaseDateTextBox.Text);
            enable_add_button();
        }

        private void CategoryComboBox_LostFocus(object sender, RoutedEventArgs e)
        {
            array[3] = check_string_availability(CategoryComboBox.Text);
            enable_add_button();
        }

        private void DescTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            array[4] = check_string_availability(DescTextBox.Text);
            enable_add_button();
        }

        private void PriceTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            array[5] = check_string_availability(PriceTextBox.Text);
            enable_add_button();
        }

        private void AmountTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            array[6] = check_string_availability(AmountTextBox.Text);
            enable_add_button();
        }
        #endregion

    }
}
