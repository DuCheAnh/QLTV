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
    public class DB_connect
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zIdueuwp4ixQMyEVF28jJEfgtp1embwR4GoKmggg",
            BasePath = "https://qltv-690d3.firebaseio.com/"
        };
    }
}
