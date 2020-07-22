using System;

namespace DTO_QuanLy
{
    public class LibCard_Data
    {
        public string LCID { get; set; }
        public string account_type { get; set; }
        public string identity_card { get; set; }
        public string name { get; set; }
        public string DOB { get; set; }
        public bool gender { get; set; }
        public DateTime created_date { get; set; }
        public bool expired { get; set; }
        public bool used { get; set; }

        public LibCard_Data(string sAccountType, string sIdentityCard, string sName
                            , string dDOB, bool bGender)
        {
            this.account_type = sAccountType;
            this.identity_card = sIdentityCard;
            this.name = sName;
            this.DOB = dDOB;
            this.gender = bGender;
        }
        public LibCard_Data()
        {
        }

    }
}
