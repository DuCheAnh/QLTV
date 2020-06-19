using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO_QuanLy
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
