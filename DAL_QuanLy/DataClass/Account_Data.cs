using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    class Account_Data
    {
        public string UID { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string profile_picture { get; set; }
        public string name { get; set; }
        public DateTime DOB { get; set; }
        public bool gender { get; set; }
        public string email { get; set; }
        public string identity_card { get; set; }
        public string account_type { get; set; }
        public Account_Data(string sUID,string sAccount,string sPassword, string sProfilePicture,string sName,
                            DateTime dDOB, bool bGender, string sEmail, string sIdentityCard, string sAccountType)
        {
            this.UID = sUID;
            this.account = sAccount;
            this.password = sPassword;
            this.profile_picture = sProfilePicture;
            this.name = sName;
            this.DOB = dDOB;
            this.gender = bGender;
            this.email = sEmail;
            this.identity_card = sIdentityCard;
            this.account_type = sAccountType;
            
        }
    }

}
