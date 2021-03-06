﻿using BUS_QuanLy;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using TestGUI_QLTV;
namespace GUI_QuanLy
{
    /// <summary>
    /// Interaction logic for User_Control_Page.xaml
    /// </summary>
    public partial class User_Control_Page : UserControl
    {

        string sUID = Data_Context.currentUID;
        User_Control_BUS User_BUS = new User_Control_BUS();
        Admin_Control_BUS admin_control = new Admin_Control_BUS();
        TestGUI_QLTV.ChangePassword changePassword = new TestGUI_QLTV.ChangePassword();
        TestGUI_QLTV.ChangeEmail changeEmail = new TestGUI_QLTV.ChangeEmail();

        public User_Control_Page()
        {
            Data_Context.currentUID = sUID;
            Data_Context.currentAccount = User_BUS.Get_Single_UserInfo(Data_Context.currentUID);
            PasswordBox passwordBox = new PasswordBox();
            passwordBox.IsEnabled = false;
            this.DataContext = Data_Context.currentAccount;
            InitializeComponent();
            if (Data_Context.currentAccount.LCID != null) User_BUS.set_libcard_to_user(Data_Context.currentAccount.LCID, sUID);
            int expiration_time = User_BUS.retrieve_usertype(Data_Context.currentAccount.account_type).expiration_time;
            if (Data_Context.currentAccount.account_type != null)
                Remaining.Content = (admin_control.Retrive_libcard_data(Data_Context.currentAccount.LCID).created_date.AddDays(expiration_time) - DateTime.Now).TotalDays;
            changeEmail.Closed += new EventHandler(changeEmail_Closed);
            changePassword.Closed += new EventHandler(changePassword_Closed);
        }
        #region when form closed event

        private void changePassword_Closed(object sender, EventArgs e)
        {
            this.DataContext = Data_Context.currentAccount;
        }

        private void changeEmail_Closed(object sender, EventArgs e)
        {
            this.DataContext = Data_Context.currentAccount;
        }
        #endregion

        private void Borrowed_Book(object sender, RoutedEventArgs e)
        {
            TestGUI_QLTV.BorrowedPage borrowedPage = new TestGUI_QLTV.BorrowedPage();
            borrowedPage.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            borrowedPage.Show();
        }

        private void Change_Email(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).IsHitTestVisible = false;
            changePassword.Hide();
            changeEmail = new TestGUI_QLTV.ChangeEmail();
            changeEmail.Owner = Window.GetWindow(this);
            changeEmail.Show();
        }

        private void Change_Password(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).IsHitTestVisible = false;
            changeEmail.Hide();
            changePassword = new TestGUI_QLTV.ChangePassword();
            changePassword.Owner = Window.GetWindow(this);
            changePassword.Show();
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.IsReadOnly = false;
            //textBox.CaretIndex = textBox.Text.Count();
            textBox.Select(50, 50);
        }



        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.IsReadOnly = true;
        }

        private void Change_profile_picture(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            //if (open.ShowDialog() == true)
            //{
            //    profileim= new BitmapImage(new Uri(open.FileName));
            //    img = Convert.ToBase64String(File.ReadAllBytes(open.FileName));
            //}
        }

        private void RedeemButton_Click(object sender, RoutedEventArgs e)
        {
            RedeemLibCardWindow redeemwindow = new RedeemLibCardWindow();
            redeemwindow.Owner = Window.GetWindow(this);
            Window.GetWindow(this).IsHitTestVisible = false;
            redeemwindow.Show();
        }


    }
    #region bool to gender converter
    public class BooltoGenderConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return "Male";
                else
                    return "Female";
            }
            return "Female";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "male":
                    return true;
                case "female":
                    return false;
            }
            return false;
        }
    }
    #endregion
    #region password binding assistant
    public static class PasswordBoxAssistant
    {
        public static readonly DependencyProperty BoundPassword =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxAssistant), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static readonly DependencyProperty BindPassword = DependencyProperty.RegisterAttached(
            "BindPassword", typeof(bool), typeof(PasswordBoxAssistant), new PropertyMetadata(false, OnBindPasswordChanged));

        private static readonly DependencyProperty UpdatingPassword =
            DependencyProperty.RegisterAttached("UpdatingPassword", typeof(bool), typeof(PasswordBoxAssistant), new PropertyMetadata(false));

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox box = d as PasswordBox;

            // only handle this event when the property is attached to a PasswordBox
            // and when the BindPassword attached property has been set to true
            if (d == null || !GetBindPassword(d))
            {
                return;
            }

            // avoid recursive updating by ignoring the box's changed event
            box.PasswordChanged -= HandlePasswordChanged;

            string newPassword = (string)e.NewValue;

            if (!GetUpdatingPassword(box))
            {
                box.Password = newPassword;
            }

            box.PasswordChanged += HandlePasswordChanged;
        }

        private static void OnBindPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            // when the BindPassword attached property is set on a PasswordBox,
            // start listening to its PasswordChanged event

            PasswordBox box = dp as PasswordBox;

            if (box == null)
            {
                return;
            }

            bool wasBound = (bool)(e.OldValue);
            bool needToBind = (bool)(e.NewValue);

            if (wasBound)
            {
                box.PasswordChanged -= HandlePasswordChanged;
            }

            if (needToBind)
            {
                box.PasswordChanged += HandlePasswordChanged;
            }
        }

        private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox box = sender as PasswordBox;

            // set a flag to indicate that we're updating the password
            SetUpdatingPassword(box, true);
            // push the new password into the BoundPassword property
            SetBoundPassword(box, box.Password);
            SetUpdatingPassword(box, false);
        }

        public static void SetBindPassword(DependencyObject dp, bool value)
        {
            dp.SetValue(BindPassword, value);
        }

        public static bool GetBindPassword(DependencyObject dp)
        {
            return (bool)dp.GetValue(BindPassword);
        }

        public static string GetBoundPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(BoundPassword);
        }

        public static void SetBoundPassword(DependencyObject dp, string value)
        {
            dp.SetValue(BoundPassword, value);
        }

        private static bool GetUpdatingPassword(DependencyObject dp)
        {
            return (bool)dp.GetValue(UpdatingPassword);
        }

        private static void SetUpdatingPassword(DependencyObject dp, bool value)
        {
            dp.SetValue(UpdatingPassword, value);
        }
    }
    #endregion
}
