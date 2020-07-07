using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class Register
    {
        DAL_Account DAL_Get = new DAL_Account();
        public bool RegisterIn(string Account,string Password,string Email)
        {
            DAL_Get.init_client();
            return DAL_Get.create_new_user(Account, Password, Email);
        }

    }
}
