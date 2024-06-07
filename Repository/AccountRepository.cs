using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class AccountRepository : IAccountRepository
{
    public async Task<Account?> GetAccount(string email, string password)
    {
        return await AccountDAO.Instance.GetAccount(email, password);
    }

    public async Task AddNewAccount(Account account)
    {
        await AccountDAO.Instance.AddNewAccount(account);
    }

    public async Task<List<Account>> GetAllAccounts()
    {
        return await AccountDAO.Instance.GetAllAccount();
    }
}