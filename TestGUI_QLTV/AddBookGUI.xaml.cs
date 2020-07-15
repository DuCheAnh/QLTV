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
using DTO_QuanLy;
using TestGUI_QLTV.Processor;
namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for AddBookGUI.xaml
    /// </summary>
    public partial class AddBookGUI : Window
    {

        public AddBookGUI()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Book_Data book = new Book_Data() { name = NameTextBox.Text, author = AuthorTextBox.Text, add_date = DateTime.Today, category = CategoryComboBox.Text, description = DescTextBox.Text, cover_page = "", price = 1, amount = Convert.ToInt32(AmountTextBox.Text) };
            //create a new popup window to notify success
            APIInit.InitClient();

            if ( await Book_data_Processor.Add_new_books(book))
            {
                TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
                popup.PopUpTB.Text = "Added a new book";
                popup.Owner = Window.GetWindow(this);
                Window.GetWindow(this).IsHitTestVisible = false;
                popup.Show();
            }
        }


        //allow it's owner to be clickable
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window.GetWindow(this).Owner.IsHitTestVisible = true;
        }



        #region only accept number input {AmountTextBox}
        private void AmountTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }

        private void AmountTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "" || NameTextBox.Text.Trim() == "")
                AddButton.IsEnabled = false;
        }
    }
}
