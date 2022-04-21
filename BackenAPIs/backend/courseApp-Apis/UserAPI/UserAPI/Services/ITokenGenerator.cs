namespace UserAPI.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(int id, string userName,string userEmail);
    }
}
