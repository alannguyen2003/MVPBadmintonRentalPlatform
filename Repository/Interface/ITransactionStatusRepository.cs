using BusinessObject;

namespace Repository.Interface;

public interface ITransactionStatusRepository
{
    public Task<List<TransactionStatus>> GetAllTransactionStatus();
    public Task AddNewTransactionStatus(TransactionStatus transactionStatus);
    public Task AddRangeTransactionStatus(List<TransactionStatus> transactionStatusList);
}