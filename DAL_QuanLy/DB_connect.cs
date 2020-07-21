using FireSharp.Config;
namespace DAL_QuanLy
{
    public class DB_connect
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "XpDorf2nT85qnkwL2ggO1xJGEEbuXsfLxODzKXyp",
            BasePath = "https://qltv-f1103.firebaseio.com/"
        };
    }
}
