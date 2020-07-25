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
    public class LibCardController : ControllerBase
    {
        #region Get method
        // GET: api/LibCard
        [HttpGet]
        public IEnumerable<LibCard_Data> Get()
        {
            IEnumerable<LibCard_Data> libcards = BUS_LibCard.Get_all_LibCard();
            return libcards;
        }

        // GET: api/LibCard/5
        [HttpGet("{id}", Name = "Get_LibCard")]
        public LibCard_Data Get(string LCID)
        {
            LibCard_Data libcard = BUS_LibCard.Get_LibCard_data(LCID);
            return libcard;
        }

        #endregion

        #region Post method
        // POST: api/LibCard
        [HttpPost]
        public bool Post([FromBody] LibCard_Data libcard)
        {
            return BUS_LibCard.Create_new_libcard(libcard);
        }

        #endregion

        #region Put method
        // PUT: api/LibCard/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // PUT api/libcard/5/useable
        [HttpPut("{LCID}/useable")]
        public void Put_useable(string LCID, [FromBody] bool value)
        {
            BUS_LibCard.Update_Useable(LCID, value);
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
