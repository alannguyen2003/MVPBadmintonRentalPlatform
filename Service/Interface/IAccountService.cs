using BusinessObject;

namespace Service.Interface;

public interface IAccountService
{
    public Task<Account?> GetAccount(string email, string password);
    public Task<Account?> GetAccount(int userId);
    public Task<string> GenerateJwtToken(Account account);
    public Task AddNewAccount(Account account);
    public Task<Account?> AddNewAccountAsync(Account account);
    public Task<Account?> RegisterOwner(Account account, BadmintonCourt badmintonCourt);
    public Task<List<Account>> GetAllAccounts();
}