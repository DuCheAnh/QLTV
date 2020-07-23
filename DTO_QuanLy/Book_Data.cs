using System;

namespace DTO_QuanLy
{
    public class Book_Data
    {
        public string BID { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public int release_year { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string cover_page { get; set; }
        public int price { get; set; }
        public int left { get; set; }
        public int amount { get; set; }
        public string added_by { get; set; }
        public DateTime add_date { get; set; }
        public Book_Data()
        {
        }
        public Book_Data(string sName, string sAuthor, int nReleaseYear, string sCategory
                         , string sDescription, string sCover_Page, int nPrice, int nAmount)
        {
            this.name = sName;
            this.author = sAuthor;
            this.release_year = nReleaseYear;
            this.category = sCategory;
            this.description = sDescription;
            this.cover_page = sCover_Page;
            this.price = nPrice;
            this.amount = nAmount;
            this.left = nAmount;
        }

    }
}
