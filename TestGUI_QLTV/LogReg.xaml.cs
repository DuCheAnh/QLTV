﻿using System;
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
using MaterialDesignThemes.Wpf;
using TestGUI_QLTV.Processor;

namespace TestGUI_QLTV
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

        }
        private void TextBox_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception mes)
            {
                MessageBox.Show(mes.Message);
            }
        }

        private void OpenForm(object sender, RoutedEventArgs e)
        {
            Window2 Rg = new Window2();
            Rg.Show();
            this.Hide();
        }

        private async void OpenMain(object sender, RoutedEventArgs e)
        {
            APIInit.InitClient();
            UserCred usercred = new UserCred();

            usercred.Username = Username.Text;
            usercred.Password = Password.Password;

            if (await Account_data_Processor.Authentication(usercred))
            {
                // attach user account to datacontext
                Data_Context.currentAccount = await Account_data_Processor.GetAccount(Data_Context.currentUID);

                //showing window
                MainWindow mn = new MainWindow();
                mn.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("sai tai khoan hoac khong co");
            }
            
        }

       
    }
  
    
}
