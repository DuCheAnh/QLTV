using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
namespace BUS_QuanLy
{
    public static class BUS_LibCard
    {
        static DAL_Libcard DAL_method = new DAL_Libcard();

        public static IEnumerable<LibCard_Data> Get_all_LibCard()
        {
            DAL_method.init_client();
            IEnumerable<LibCard_Data> accounts = DAL_method.retrieve_all_libcard();
            return accounts;
        }

        public static LibCard_Data Get_LibCard_data(string LCID)
        {
            DAL_method.init_client();
            return DAL_method.retrieve_libcard_data(LCID);
        }

        public static void Update_Useable(string LCID, bool value)
        {
            DAL_method.init_client();
            DAL_method.update_libcard_usedable(LCID, value);
        }

        public static bool Create_new_libcard(LibCard_Data libcard)
        {
            DAL_method.init_client();
            return DAL_method.create_new_libcard(libcard.account_type, libcard.identity_card, libcard.name, libcard.DOB, libcard.gender);
        }
    }
}
