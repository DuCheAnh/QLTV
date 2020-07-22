using BUS_QuanLy;
using GUI_QuanLy;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUS_QuanLy;
using System.Windows.Automation.Peers;
using DTO_QuanLy;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        User_Control_BUS Bus_method = new User_Control_BUS();
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
            //BookDataUI bData = new BookDataUI();
            UserDataUI uData = new UserDataUI();
            spMain.Children.Add(uData);
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
                User_Control_BUS control_BUS = new User_Control_BUS();
            Data_Context.currentAccount = null;
            Data_Context.currentUID = null;
            Data_Context.currentHomePageBook = null;
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
