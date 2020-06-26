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
    //[Authorize]
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
        //get all account
        [HttpGet]
        public IEnumerable<Account_Data> Get()
        {
            DAL_method.init_client();

            IEnumerable<Account_Data> Accounts = DAL_method.retrieve_all_user_data();
            return Accounts;
        }

        // GET: api/Account/5
        // get specific account /by id
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
        // create new account
        [HttpPost]
        public string Post([FromBody] Account_Data data)
        {
            DAL_method.init_client();

            //DAL_method.insert_data_to_table(data);// need bool
            if (false /*cant create account*/)
            {
                return "cant create account";
            }

            return "successfully created";
        }

        //POST: api/account/{id}
        // method not allowed

        //PUT: api/account
        // Bulk Update on all account
        [HttpPut]
        public void Put([FromBody] IEnumerable<Account_Data> accounts )
        {
            // need update all account data one by one account_DAL
        }

        // PUT: api/Account/5
        // update specific account
        [HttpPut("{id}")]
        public void Put([FromBody] Account_Data account)
        {
            DAL_method.init_client();
            DAL_method.update_data_to_table(account);// need bool

            // need return value
        }

        // DELETE: api/ApiWithActions/5
        // delete specific account ioc: delete your self
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            DAL_method.init_client();
            DAL_method.delete_from_table(id); // need bool

            //need return value
        }


        // DELETE : api/account
        //delete all account
        /*undone*/

        // POST: api/account/authenticate
        // Authenticate before use
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Model.UserCred usercred)
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
