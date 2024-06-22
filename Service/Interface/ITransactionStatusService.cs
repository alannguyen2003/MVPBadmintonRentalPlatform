using BusinessObject;

namespace Service.Interface;

public interface ITransactionStatusService
{
    public Task<List<TransactionStatus>> GetAllTransactionStatus();
    public Task AddNewTransactionStatus(TransactionStatus transactionStatus);
    public Task AddRangeTransactionStatus(List<TransactionStatus> transactionStatusList);
}