using BusinessObject;

namespace Repository.Interface;

public interface ITransactionTypeRepository
{
    public Task<List<TransactionType>> GetAllTransactionType();
    public Task AddNewTransactionType(TransactionType transactionType);
    public Task AddRangeTransactionType(List<TransactionType> transactionTypes);
}