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
    public class User_Control_BUS
    {
        User_Control_DAL data = new User_Control_DAL();

        public User_Control_BUS()
        {
        }

        public void Get_User_Info(DataGrid Info_grid)
        {
            Info_grid.ItemsSource = data.Get_User_Data();
        }

        public void Update_User_Info(List<User> Updated_Users)
        {
            data.Update_Users_data(Updated_Users);
        }
    }

}
