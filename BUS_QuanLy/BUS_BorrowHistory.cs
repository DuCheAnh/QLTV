using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;

namespace BUS_QuanLy
{
    public static class BUS_BorrowHistory
    {
        static DAL_Borrow DAL_method = new DAL_Borrow();

        public static void Add_borrow_data(Borrow_Data newborrow)
        {
            DAL_method.init_client();
            DAL_method.add_new_borrow(newborrow.BID, newborrow.UID, newborrow.borrow_date);
        }

        public static List<Borrow_Data> Retrieve_all_borrows()
        {
            DAL_method.init_client();
            return DAL_method.retrieve_all_borrows();
        }
    }
}
