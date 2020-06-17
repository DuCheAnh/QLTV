using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
namespace DAL_QuanLy
{
    class DB_connect
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "XpDorf2nT85qnkwL2ggO1xJGEEbuXsfLxODzKXyp",
            BasePath = "https://qltv-f1103.firebaseio.com/"
        };
    }
}
