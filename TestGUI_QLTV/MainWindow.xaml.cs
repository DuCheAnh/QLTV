using BUS_QuanLy;
using GUI_QuanLy;
using System;
using System.Windows;

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
            InitializeComponent();
            Data_Context.currentHomePageBook = Bus_method.Get_all_Books();
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



        private void bthSearch_Click(object sender, RoutedEventArgs e)
        {
            Data_Context.currentHomePageBook = Bus_method.Search_for_book(Search_box.Text);
            spMain.Children.Clear();
            if (Data_Context.currentHomePageBook.Count != 0)
            {
                MainPage mPage = new MainPage();
                spMain.Children.Add(mPage);
            }
        }

        private void btnBell_Click(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();
            //BookDataUI Data = new BookDataUI();
           UserDataUI Data = new UserDataUI();
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
