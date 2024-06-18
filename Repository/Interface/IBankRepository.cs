using BusinessObject;

namespace Repository.Interface;

public interface IBankRepository
{
    public Task<List<Bank>> GetAllBanks();
    public Task AddNewBank(Bank bank);
    public Task AddRangeBanks(List<Bank> banks);
}