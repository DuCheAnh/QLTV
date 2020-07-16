using GUI_QuanLy;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BUS_QuanLy;
using System.Windows.Automation.Peers;
using DTO_QuanLy;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        User_Control_BUS Bus_method = new User_Control_BUS();

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
            BookDataUI bData = new BookDataUI();
            spMain.Children.Add(bData);
        }

        public void btnCart_Click(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();
            BookPage bPage = new BookPage();
            spMain.Children.Add(bPage);
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            spMain.Children.Clear();
            User_Control_Page UCUser = new User_Control_Page();
            spMain.Children.Add(UCUser);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        { 
            Environment.Exit(Environment.ExitCode);
        }
    }
}
