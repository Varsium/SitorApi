namespace SitorApi.Security
{
    public interface IJwtAuthenticationManger
    {
        string Authenticate(string username, string password);
    }

}
