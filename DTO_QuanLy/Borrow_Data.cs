using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class Borrow_Data
    {
        public string BrID;
        public string BID;
        public DateTime borrow_date;
        public DateTime return_date;
        public int overdue_by;
        public bool returned;
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
