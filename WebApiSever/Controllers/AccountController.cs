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
        BUS_Account BUS_method = new BUS_Account();

        // GET: api/Account
        //get all account
        [HttpGet]
        public IEnumerable<Account_Data> Get()
        {
            IEnumerable<Account_Data> Accounts = BUS_method.retrieve_all_user_data();
            return Accounts;
        }

        // GET: api/Account/5
        // get specific account /by id
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {

            Account_Data account = BUS_method.retrieve_user_data(id.ToString());

            if (account == null)
                return NotFound();

            return Ok(account);
        }

        // POST: api/Account
        // create new account
        [HttpPost]
        public string Post([FromBody] Account_Data data)
        {
            bool created = BUS_method.Create_new_account(data);
            //DAL_method.insert_data_to_table(data);// need bool
            if (created)
            {
                return "successfully created";
            }
            return "cant create account";
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
        public IActionResult Put([FromBody] Account_Data account)
        {

            BUS_method.Update_account(account);// need bool
            return Ok(BUS_method.Update_account(account));

            // need return value
        }

        // DELETE: api/ApiWithActions/5
        // delete specific account ioc: delete your self
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            BUS_method.Delete_specific_account(id); // need bool

            //need return value
        }


        // DELETE : api/account
        //delete all account
        /*undone*/

        #region authentication
        private readonly IJwtAuthenticationManager jwtAuthenticationmanager;

        public AccountController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationmanager = jwtAuthenticationManager;
        }


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
        #endregion

    }
}
