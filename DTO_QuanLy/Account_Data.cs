using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class Account_Data
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
        public string LCID { get; set; }
        public List<string> BrID { get; set; }
        public Account_Data(string sAccount, string sPassword, string sEmail)
        {
            this.account = sAccount;
            this.password = sPassword;
            this.email = sEmail;
        }
        public Account_Data(string sName, DateTime dtDOB, bool bGender, string sIdentifyCard,
                            string sAccountType)
        {
            this.name = sName;
            this.DOB = dtDOB;
            this.gender = bGender;
            this.identity_card = sIdentifyCard;
            this.account_type = sAccountType;
        }
        public Account_Data(string sLCID)
        {
            this.LCID = sLCID;
        }
        public Account_Data() { }
    }

}
