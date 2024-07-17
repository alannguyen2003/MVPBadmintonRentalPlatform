using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class TransactionTypeService : ITransactionTypeService
{
    private readonly ITransactionTypeRepository _transactionTypeRepository;

    public TransactionTypeService(ITransactionTypeRepository transactionTypeRepository)
    {
        _transactionTypeRepository = transactionTypeRepository;
    }
    
    public async Task<List<TransactionType>> GetAllTransactionType()
    {
        return await _transactionTypeRepository.GetAllTransactionType();
    }

    public async Task AddNewTransactionType(TransactionType transactionType)
    {
        await _transactionTypeRepository.AddNewTransactionType(transactionType);
    }

    public async Task AddRangeTransactionType(List<TransactionType> transactionTypes)
    {
        await _transactionTypeRepository.AddRangeTransactionType(transactionTypes);
    }

    public async Task<List<TransactionType>> GetAllExpenditureRecord()
    {
        return await _transactionTypeRepository.GetAllExpenditureType();
    }
}