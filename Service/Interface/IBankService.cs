using BusinessObject;

namespace Service.Interface;

public interface IBankService
{
    public Task<List<Bank>> GetAllBanks();
    public Task AddNewBank(Bank bank);
    public Task AddRangeBanks(List<Bank> banks);
}