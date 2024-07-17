using BusinessObject;

namespace Service.Interface;

public interface ITransactionTypeService
{
    public Task<List<TransactionType>> GetAllTransactionType();
    public Task AddNewTransactionType(TransactionType transactionType);
    public Task AddRangeTransactionType(List<TransactionType> transactionTypes);
    public Task<List<TransactionType>> GetAllExpenditureRecord();
    
}