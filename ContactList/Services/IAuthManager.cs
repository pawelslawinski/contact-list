using ContactList.Domain;

namespace ContactList.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLogin userToValidate);
        Task<string> GenerateToken();
    }
}
