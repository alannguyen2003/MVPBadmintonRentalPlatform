using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class BankRepository : IBankRepository
{
    public async Task<List<Bank>> GetAllBanks()
    {
        return await BankDAO.Instance.GetAllBanks();
    }

    public async Task AddNewBank(Bank bank)
    {
        await BankDAO.Instance.AddNewBank(bank);
    }

    public async Task AddRangeBanks(List<Bank> banks)
    {
        await BankDAO.Instance.AddRangeBanks(banks);
    }
}