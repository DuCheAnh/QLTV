using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class Borrow_Data
    {
        public string BrID { get; set; }
        public string BID { get; set; }
        public string UID { get; set; }
        public DateTime borrow_date { get; set; }
        public DateTime return_date { get; set; }
        public int overdue_by { get; set; }
        public bool returned { get; set; }
        public Borrow_Data()
        {
        }
        public Borrow_Data(string sBrID, string sBID, DateTime dBorrowDate, DateTime dReturnDate, int nOverdueBy, bool bReturned )
        {
            this.BrID = sBrID;
            this.BID = sBID;
            this.borrow_date = dBorrowDate;
            this.return_date = dReturnDate;
            this.overdue_by = nOverdueBy;
            this.returned = bReturned;
        }
    }
}
