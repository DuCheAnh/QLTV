using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;
using System.Windows.Controls;


namespace BUS_QuanLy
{
    public class Admin_Control_BUS
    {
        Admin_Control_DAL data = new Admin_Control_DAL();

        /// <summary>
        /// gan data tu DAl => grid trong GUI
        /// </summary>
        /// <param name="Info_grid"></param>
        public void Get_User_Info(DataGrid Info_grid)
        {
            Info_grid.ItemsSource = data.Get_Users_Data();
        }

        /// <summary>
        /// 1) dang le phai check kieu data truoc khi truyen xuong dal
        /// 2) truyen list nhung user can phai update xuong dal
        /// </summary>
        /// <param name="Updated_Users"></param>
        public void Update_User_Info(List<User> Updated_Users)
        {
            data.Update_Users_data(Updated_Users);
        }
    }
}
