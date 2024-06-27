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

    public async Task<Account?> GetAccount(int userId)
    {
        return await AccountDAO.Instance.GetAccount(userId);
    }

    public async Task AddNewAccount(Account account)
    {
        await AccountDAO.Instance.AddNewAccount(account);
    }

    public async Task<Account?> AddNewAccountAsync(Account account)
    {
        return await AccountDAO.Instance.AddNewAccountAsync(account);
    }

    public async Task AddRangeAccountAsync(List<Account> accounts)
    {
        await AccountDAO.Instance.AddRangeAccountAsync(accounts);
    }

    public async Task<Account?> RegisterNewOwner(Account account, BadmintonCourt badmintonCourt, List<ServiceCourt> services)
    {
        var accountOwner = await AuthenticationDAO.Instance.OwnerRegister(account, badmintonCourt, services);
        return accountOwner;
    }

    public async Task<List<Account>> GetAllAccounts()
    {
        return await AccountDAO.Instance.GetAllAccount();
    }

    public async Task<List<Account>> GetAccontWithRole(int roleId)
    {
        return await AccountDAO.Instance.GetAccountWithRole(roleId);
    }

    public async Task EditProfileAsync(Account account)
    {
        var accountResponse = await GetAccount(account.Id);
        accountResponse.Email = account.Email;
        accountResponse.FullName = account.FullName;
        accountResponse.PhoneNumber = account.PhoneNumber;
        await AccountDAO.Instance.EditProfile(accountResponse);
    }

    public async Task<int> GetNumberOfPlayer()
    {
        return await AccountDAO.Instance.GetNumberOfPlayer();
    }

    public async Task<int> GetNumberOfOwner()
    {
        return await AccountDAO.Instance.GetNumberOfOwner();
    }
}