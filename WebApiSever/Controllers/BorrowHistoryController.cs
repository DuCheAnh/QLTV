using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DTO_QuanLy;
using BUS_QuanLy;
using Microsoft.AspNetCore.Authorization;

namespace WebApiSever.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowHistoryController : ControllerBase
    {
        #region Get method
        // GET: api/BorrowHistory
        [HttpGet]
        public List<Borrow_Data> Get()
        {
            return BUS_BorrowHistory.Retrieve_all_borrows();
        }

        // GET: api/BorrowHistory/5
        [HttpGet("{id}", Name = "Get_BorrowHistory")]
        public string Get(int id)
        {
            return "value";
        }
        #endregion

        #region Post method
        // POST: api/BorrowHistory
        [HttpPost]
        public void Post([FromBody] Borrow_Data newborrow)
        {
            BUS_BorrowHistory.Add_borrow_data(newborrow);
        }

        #endregion

        #region Put method
        // PUT: api/BorrowHistory/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        #endregion

        #region Delete method
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}
