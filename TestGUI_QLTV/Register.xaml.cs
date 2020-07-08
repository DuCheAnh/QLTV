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
using BUS_QuanLy;

namespace TestGUI_QLTV
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Register Bus_register = new Register();
        public Window2()
        {
            InitializeComponent();
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

        private void Back(object sender, RoutedEventArgs e)
        {
            Window1 Rg =new Window1();
            Rg.Show();
            this.Close();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            if (Bus_register.RegisterIn(Username.Text, Password.Password,Email.Text))
            {
                MessageBox.Show("Dang ki thanh cong");
                this.Back(sender,e);
                
            }

        }
    }
}