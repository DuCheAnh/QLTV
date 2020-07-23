namespace WebApiSever.Interface
{
    public interface IJwtAuthenticationManager
    {
        Model.UserToken Authenticate(string username, string password);
    }

}
