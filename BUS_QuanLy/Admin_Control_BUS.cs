using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;
using System.Windows;
using System.Windows.Controls;

namespace BUS_QuanLy
{
    public class Admin_Control_BUS
    {
        DAL_Account Account_DAL = new DAL_Account();
        DAL_Libcard Libcard_DAL = new DAL_Libcard();

        /// <summary>
        /// gan data tu DAl => grid trong GUI
        /// </summary>
        /// <param name="Info_grid"></param>
        public void Get_User_Info(DataGrid Info_grid)
        {
            Account_DAL.init_client();
           // Info_grid.ItemsSource = Account_DAL.retrieve_all_user_data();
        }

        /// <summary>
        /// 1) dang le phai check kieu data truoc khi truyen xuong dal
        /// 2) truyen list nhung user can phai update xuong dal
        /// </summary>
        /// <param name="Updated_Users"></param>
        public void Update_User_Info(List<Account_Data> Updated_Users)
        {
            Account_DAL.init_client();
            //Acount_DAL.Update_Users_data(Updated_Users);
        }
        public bool create_new_libcard(string sAccountType, string sIdentityCard
                    , string sName, DateTime dDOB, bool bGender)
        {
            Libcard_DAL.init_client();
            return Libcard_DAL.create_new_libcard(sAccountType, sIdentityCard, sName, dDOB, bGender);
        }

    }
}
