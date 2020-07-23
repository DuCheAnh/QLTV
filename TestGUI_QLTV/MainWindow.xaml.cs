using GUI_QuanLy;
using System;
using System.Windows;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        bool IsLogout = false;

        public MainWindow()
        {
            APIInit.InitClient();
            InitializeComponent();

            GetAllBooks();

        }

        private async void GetAllBooks()
        {
            Data_Context.currentBooksdataUI = await Book_data_Processor.Get_all_books();

            MainMenu mMenu = new MainMenu();
            spMenu.Children.Add(mMenu);
            MainPage mPage = new MainPage();
            spMain.Children.Add(mPage);
            
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();
            MainPage mPage = new MainPage();
            spMain.Children.Add(mPage);

            spMenu.Children.Clear();
            MainMenu mMenu = new MainMenu();
            spMenu.Children.Add(mMenu);
        }

        private async void bthSearch_Click(object sender, RoutedEventArgs e)
        {
            Data_Context.currentBooksdataUI = await Book_data_Processor.Search_Books(Search_box.Text);
            ;
            spMain.Children.Clear();
            if (Data_Context.currentBooksdataUI != null)
            {
                MainPage mPage = new MainPage();
                spMain.Children.Add(mPage);
            }
            else
            {
                Data_Context.currentBooksdataUI = await Book_data_Processor.Get_all_books();

                MainPage mPage = new MainPage();
                spMain.Children.Add(mPage);
            }
        }

        private void btnBell_Click(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();
            //BookDataUI Data = new BookDataUI();
            BorrowedHistoryUI Data = new BorrowedHistoryUI();
            //UserDataUI Data = new UserDataUI();
            spMain.Children.Add(Data);
        }

        public void btnCart_Click(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();
            LibCardDataUI libcardData = new LibCardDataUI();
            spMain.Children.Add(libcardData);
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();
            User_Control_Page UCUser = new User_Control_Page();
            spMain.Children.Add(UCUser);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Đăng xuất ?", "Question", MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    Data_Context.currentAccount = null;
                    Data_Context.currentUID = null;
                    Data_Context.currentHomePageBook = null;
                    Data_Context.Token = null;

                    IsLogout = true;
                    Window1 Login = new Window1();
                    Window.GetWindow(this).Close();
                    Login.Show();
                            break;
                case MessageBoxResult.Cancel:
                    break;

            }
        }
        
        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsLogout == true)
            {
                IsLogout = false;
            }
            else
            {
                Environment.Exit(Environment.ExitCode);
            }
        }
    }
}
