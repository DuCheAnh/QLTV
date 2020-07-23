﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : UserControl
    {

        public BookPage()
        {
            InitializeComponent();
            init_book_page();
        }

        private void AmountLeftTextBlock_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            AmountLeftTextBlock.Text += " in stock";
        }

        public void init_book_page()
        {
            this.NameTextBlock.Text = Data_Context.selected_book.name;
            this.AuthorTextBlock.Text = Data_Context.selected_book.author;
            this.AmountLeftTextBlock.Text = Data_Context.selected_book.left.ToString() + " in stocks";
            this.ReleaseYearTextBlock.Text = "xuất bản " + Data_Context.selected_book.release_year.ToString();
            this.DescriptionTextBlock.Text = Data_Context.selected_book.description;
            if (Data_Context.selected_book.left < 1) this.BorrowButton.IsEnabled = false;
        }

        private async void BorrowButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await Borrow_data_Processor.add_borrow_data(Data_Context.selected_book.BID, Data_Context.currentUID, DateTime.Now);
            /*user_control.add_borrow_data(Data_Context.selected_book.BID, Data_Context.currentUID, DateTime.Now);*/
            TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
            popup.PopUpTB.Text = "added";
            popup.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            popup.Show();
        }
    }
}
