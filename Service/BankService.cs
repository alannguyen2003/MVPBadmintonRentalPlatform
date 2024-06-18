using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class BankService : IBankService
{
    private readonly IBankRepository _bankRepository;

    public BankService(IBankRepository bankRepository)
    {
        _bankRepository = bankRepository;
    }
    
    public async Task<List<Bank>> GetAllBanks()
    {
        return await _bankRepository.GetAllBanks();
    }

    public async Task AddNewBank(Bank bank)
    {
        await _bankRepository.AddNewBank(bank);
    }

    public async Task AddRangeBanks(List<Bank> banks)
    {
        await _bankRepository.AddRangeBanks(banks);
    }
}