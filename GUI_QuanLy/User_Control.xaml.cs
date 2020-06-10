using System;
using System.Collections.Generic;
using System.Data;
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
using DTO_QuanLy;

namespace GUI_QuanLy
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        User_Control_BUS User = new User_Control_BUS();
        bool Clicked = false;
        List<User> Updated_Users = new List<User>();

        public Window1()
        {
            InitializeComponent();
        }

        //pass datagrid down BUS
        private void User_Get_Info_button_Click(object sender, RoutedEventArgs e)
        {
            User.Get_User_Info(User_Info_Datagrid);
            Clicked = true;
        }

        /// <summary>
        /// 1) check xem thu nut get info bam chua
        /// 2) roi thi truyen xuong bus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void User_Update_Info_button_Click(object sender, RoutedEventArgs e)
        {

            if (Clicked)
            {
                User.Update_User_Info(Updated_Users);
                //MessageBox.Show(User.Update_User_Info(User_Info_Datagrid));
            }
            else
            {
                MessageBox.Show("u havent selected anything");
            }


        }


        /// <summary>
        /// 1) check thu hanh dong co phai la edit cell trong grid khong
        /// 2) neu hanh dong da dc commit thi lay item la 1 user truyen vao list updated user 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void User_Info_Datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                Updated_Users.Add(User_Info_Datagrid.SelectedItem as User);
            }
        }
    }
}
