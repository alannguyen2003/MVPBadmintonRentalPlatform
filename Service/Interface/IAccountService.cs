using BusinessObject;

namespace Service.Interface;

public interface IAccountService
{
    public Task<Account?> GetAccount(string email, string password);
    public Task<string> GenerateJwtToken(Account account);
    public Task AddNewAccount(Account account);
    public Task<List<Account>> GetAllAccounts();
}