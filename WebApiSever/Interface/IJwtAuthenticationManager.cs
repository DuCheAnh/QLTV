using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSever.Interface
{
    public interface IJwtAuthenticationManager
    {
        Model.UserToken Authenticate(string username, string password);
    }

}
