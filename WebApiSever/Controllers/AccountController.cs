using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSever.Interface;
using WebApiSever.Model;
using BUS_QuanLy;
using DAL_QuanLy;
using DTO_QuanLy;

namespace WebApiSever.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        DAL_Account DAL_method = new DAL_Account();

        private readonly IJwtAuthenticationManager jwtAuthenticationmanager;

        public AccountController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationmanager = jwtAuthenticationManager;
        }

        // GET: api/Account
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "cuong", "123" };
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            DAL_method.init_client();
            Account_Data account = DAL_method.retrieve_user_data(id.ToString());
            if (account == null)
                return NotFound();

            return Ok(account);
        }

        // POST: api/Account
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred usercred)
        {
            var token = jwtAuthenticationmanager.Authenticate(usercred.Username, usercred.Password);
            if(token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
