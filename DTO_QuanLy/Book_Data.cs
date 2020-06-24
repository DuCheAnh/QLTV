using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class Book_Data
    {
        public string BID;
        public string name;
        public string author;
        public DateTime release_date;
        public string category;
        public string description;
        public string cover_page;
        public int price;
        public int amount;
        public string added_by;
        public string add_date;
        public Book_Data()
        {
        }
        public Book_Data(string sBID, string sName, string sAuthor, DateTime dReleaseDate, string sCategory
                         , string sDescription, string sCover_Page, int nPrice, int nAmount, string sAdded_By, string sAdd_Date )
        {
            this.BID = sBID;
            this.name = sName;
            this.author = sAuthor;
            this.release_date = dReleaseDate;
            this.category = sCategory;
            this.description = sDescription;
            this.cover_page = sCover_Page;
            this.price = nPrice;
            this.amount = nAmount;
            this.added_by = sAdded_By;
            this.add_date = sAdd_Date;
        }

    }
}
