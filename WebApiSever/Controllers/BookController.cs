using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DTO_QuanLy;
using BUS_QuanLy;

namespace WebApiSever.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        #region Get method
        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book_Data> Get()
        {
            IEnumerable<Book_Data> books = BUS_Book.Get_all_books();
            return books;
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult Get(string id)
        {
            Book_Data book = BUS_Book.Retrive_book_data(id.ToString());

            if (book == null)
                return NotFound();

            return Ok(book);

        }

        // get: api/Book/Search:text
        [HttpGet("Search:{text}")]
        public IEnumerable<Book_Data> Search(string text)
        {
            IEnumerable<Book_Data> books = BUS_Book.Search(text);

            return books;
        }
        #endregion

        #region Post method
        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] Book_Data data)
        {
            bool created = BUS_Book.Create_new_book(data);
            if(created)
            {
                return Ok();
            }
            return NotFound();
        }

        //post: api/book/{id}
        //method not allowed
        #endregion

        #region Put method
        //put : api/Book
        //bulk update on all books
        [HttpPut]
         public void Put([FromBody] IEnumerable<Book_Data> books)
        {

        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Book_Data book)
        {
           
            return Ok(BUS_Book.Update_on_book(book));
        }
        #endregion

        #region Delete method
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            BUS_Book.Delete_specific_book(id);
        }
        #endregion
    }
}
