﻿using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using System.Security.Principal;

namespace BUS_QuanLy
{
    public class Login
    {
        DAL_Account DAL_method =new DAL_Account();
        List<Account_Data> possible_account = new List<Account_Data>();
        public bool LoginMethod(string username, string Password)
        {
            DAL_method.init_client();
            possible_account =  DAL_method.retrieve_all_user();

            foreach(Account_Data account in possible_account)
            {
                if (account.account == username && account.password == Password)
                    return true;
            }

            return false;
        }
    }
}