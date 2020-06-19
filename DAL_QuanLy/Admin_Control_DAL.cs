using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;


namespace DAL_QuanLy
{
    public class Admin_Control_DAL
    {


        /// <summary>
        /// 1) lay database len thanh 1 list user 
        /// 1) tra list user ay len BUS
        /// </summary>
        /// <returns></returns>
        public List<User> Get_Users_Data()
        {
            List<User> users = new List<User>();

            users.Add(new User() { ID = 1, Name = "cuong", DOB = new DateTime(2000, 2, 28), Gender = true });
            users.Add(new User() { ID = 2, Name = "cuong", DOB = new DateTime(2000, 2, 28), Gender = true });
            users.Add(new User() { ID = 3, Name = "cuong", DOB = new DateTime(2000, 2, 28), Gender = true });
            users.Add(new User() { ID = 4, Name = "cuong", DOB = new DateTime(2000, 2, 28), Gender = true });

            return users;
        }

        /// <summary>
        /// 1) lay dau vao la 1 list user can thay doi
        /// 2) neu commit len database dc thi tra ve gia tri true
        /// 2.1) neu khong commit len database duoc se tra gia tri false
        /// </summary>
        /// <param name="Need_to_Change_Users"></param>
        /// <returns></returns>
        public bool Update_Users_data(List<User> Need_to_Change_Users)
        {

            if (/*sync to database action == true*/true)
            {

                return true;
            }

            return false;
        }

    }
}
