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
using DTO_QuanLy;
using System.Net.Http;

namespace WebApiSever.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Get method
        // GET: api/Account
        //get all account
        [HttpGet]
        public IEnumerable<Account_Data> Get()
        {
            IEnumerable<Account_Data> Accounts = BUS_Account.retrieve_all_user_data();
            return Accounts;
        }

        // GET: api/Account/5
        // get specific account /by id
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {

            Account_Data account = BUS_Account.retrieve_user_data(id.ToString());

            if (account == null)
                return NotFound();

            return Ok(account);
        }
        #endregion

        #region Post method
        // POST: api/Account
        // create new account
        [HttpPost]
        public bool Post([FromBody] UserRegister data)
        {
            return BUS_Account.Create_new_account(data);
        }

        //Post: api/account/{id}CheckoldPassword
        [HttpPost("{UID}/checkoldPassword")]
        public bool Post_Check_Password(string UID, [FromBody] string OldPassword)
        {
            return BUS_Account.Check_account_oldPassword(UID, OldPassword);
        }

        //POST: api/account/{id}
        // method not allowed

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
            if (token == null)
            {
                return Unauthorized();
            }


            return Ok(token);
        }
        #endregion

        #endregion

        #region Put method
        // PUT: api/account/{id}/changeEmail
        [HttpPut("{UID}/changeEmail")]
        public void PUT_Change_Email(string UID, [FromBody] string newEmail)
        {
            BUS_Account.Update_Account_Email(UID, newEmail);
        }


        // PUT: api/account/{id}/changePassword
        [HttpPut("{UID}/changePassword")]
        public void PUT_Change_Password(string UID, [FromBody] string newPassword)
        {
            BUS_Account.Update_account_Password(UID, newPassword);
        }

        //PUT: api/account
        // Bulk Update on all account
        [HttpPut]
        public void Put([FromBody] IEnumerable<Account_Data> accounts)
        {
            // need update all account data one by one account_DAL
        }

        // PUT: api/Account/5
        // update specific account
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Account_Data account)
        {

            BUS_Account.Update_account(account);// need bool
            return Ok(BUS_Account.Update_account(account));

            // need return value
        }
        #endregion

        #region Delete method
        // DELETE: api/ApiWithActions/5
        // delete specific account ioc: delete your self
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            BUS_Account.Delete_specific_account(id); // need bool

            //need return value
        }


        // DELETE : api/account
        //delete all account
        /*undone*/
        #endregion


    }
}
