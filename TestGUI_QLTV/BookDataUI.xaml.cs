using DTO_QuanLy;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for BookDataUI.xaml
    /// </summary>
    public partial class BookDataUI : UserControl
    {

        public BookDataUI()
        {

            InitializeComponent();
            init_datasource("");
/*            loadbooks();*/

        }

        public async void init_datasource(string sKey)
        {
            List<Book_Data> book_list = new List<Book_Data>();
            foreach (Book_Data data in await Book_data_Processor.Get_all_books())
            {
                if (data.name.Contains(sKey) || data.category.Contains(sKey) || data.author.Contains(sKey) || data.description.Contains(sKey))
                    book_list.Add(data);
            }
            BookDataListView.ItemsSource = book_list;
        }

        private void btnAddBook(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.AddBookGUI addBookGUI = new TestGUI_QLTV.AddBookGUI();
            addBookGUI.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            addBookGUI.Show();
        }

        private async void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.EditBookGUI editBookGUI = new TestGUI_QLTV.EditBookGUI();
            if (BookDataListView.SelectedItems.Count > 1)
            {
                foreach (Book_Data data in BookDataListView.SelectedItems)
                {
                    await Book_data_Processor.Delete_specific_Book(data.BID);
                    /*admin_control.delete_book(data.BID);*/
                }
                TestGUI_QLTV.PopUpWindow popup = new TestGUI_QLTV.PopUpWindow();
                popup.PopUpTB.Text = "Deleted";
                popup.Owner = Window.GetWindow(this);
                Window.GetWindow(this).IsHitTestVisible = false;
                popup.Show();
            }
            else
            {
                editBookGUI.set_value_from_item((Book_Data)BookDataListView.SelectedItems[0]);
                editBookGUI.Owner = Window.GetWindow(this);
                Window.GetWindow(this).IsHitTestVisible = false;
                editBookGUI.Show();
            }

        }

        private void BookDataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookDataListView.SelectedItems.Count > 0)
            {
                if (BookDataListView.SelectedItems.Count > 1)
                    EditBookButton.Content = "DELETE " + BookDataListView.SelectedItems.Count.ToString();
                else EditBookButton.Content = "EDIT";
                EditBookButton.IsEnabled = true;
            }
            else EditBookButton.IsEnabled = false;
        }

        private void UserControl_IsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            init_datasource("");

        }


        private void ListViewSearchBar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                init_datasource(ListViewSearchBar.Text);
            }


        }
        private async void loadbooks()
        {
            APIInit.InitClient();
            Data_Context.currentBooksdataUI = await Book_data_Processor.Get_all_books();
            BookDataListView.ItemsSource = Data_Context.currentBooksdataUI;
        }

    }
} 
