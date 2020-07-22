using BUS_QuanLy;
using DTO_QuanLy;
using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using DTO_QuanLy;
using System.IO;
using Microsoft.Win32;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for AddBookGUI.xaml
    /// </summary>
    public partial class EditBookGUI : Window
    {
        bool[] array = new bool[7];
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        Book_Data selected_book;
        string img = null;

        public EditBookGUI()
        {
            InitializeComponent();
        }

        public void set_value_from_item(Book_Data data)
        {
            this.selected_book = data;
            this.NameTextBox.Text = selected_book.name;
            this.AuthorTextBox.Text = selected_book.author;
            this.ReleaseYearTextBox.Text = selected_book.release_year.ToString();
            for (int i = 0; i < this.CategoryComboBox.Items.Count; i++)
            {
                if (this.CategoryComboBox.Items[i].ToString().Contains(selected_book.category))
                {
                    this.CategoryComboBox.SelectedIndex = i;
                    array[3] = check_string_availability(CategoryComboBox.Text);
                    enable_add_button();
                }
            }
            this.DescTextBox.Text = selected_book.description;
            this.PriceTextBox.Text = selected_book.price.ToString();
            this.AmountTextBox.Text = selected_book.amount.ToString();

            byte[] binaryData = Convert.FromBase64String(selected_book.cover_page);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();
            PictureX.Source = bi;
        }

        private void btnClose(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private async void edit_book()
        {
            Book_Data book = new Book_Data()
            {
                name = NameTextBox.Text,
                author = AuthorTextBox.Text,
                release_year = Convert.ToInt32(ReleaseYearTextBox.Text),
                category = CategoryComboBox.Text,
                description = DescTextBox.Text,
                cover_page = "" /* coverpage */,
                price = Convert.ToInt32(PriceTextBox.Text),
                amount = Convert.ToInt32(AmountTextBox.Text)
            };
            await Book_data_Processor.Delete_specific_Book(selected_book.BID);
            await Book_data_Processor.Add_new_book(book);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            edit_book();
            //create a new popup window to notify success
            TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
            popup.PopUpTB.Text = "Updated";
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
            for (int i = 0; i < 7; i++)
            {
                if (array[i] == false) bCheck = false;
            }
            if (bCheck == true) EditButton.IsEnabled = true;
            else EditButton.IsEnabled = false;
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
            array[2] = check_string_availability(ReleaseYearTextBox.Text);
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

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            await Book_data_Processor.Delete_specific_Book(selected_book.BID);

            TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
            popup.PopUpTB.Text = "Deleted";
            popup.Owner = Window.GetWindow(this.Owner);
            this.Close();
            Window.GetWindow(this.Owner).IsHitTestVisible = false;
            popup.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == true)
            {
                PictureX.Source = new BitmapImage(new Uri(open.FileName));
                img = Convert.ToBase64String(File.ReadAllBytes(open.FileName));
            }
        }
    }
}
