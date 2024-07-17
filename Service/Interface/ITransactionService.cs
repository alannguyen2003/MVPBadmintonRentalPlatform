using BusinessObject;

namespace Service.Interface;

public interface ITransactionService
{
    public Task<List<Transaction>> GetAllTransaction();
    public Task<List<Transaction>> GetAllTransactionByAccount(int accountId);
    public Task<List<Transaction>> GetAllTransactionByType(int transactionTypeId);
    public Task<List<Transaction>> GetAllTransactionByStatus(int transactionStatusId);
    public Task AddNewTransaction(Transaction transaction);
    public Task AddRangeTransaction(List<Transaction> transactions);
    public Task<Transaction?> GetTransaction(int transactionId);
    public Task ApproveTransaction(Transaction transaction);
    public Task RejectTransaction(Transaction transaction);
    public Task AddNewExpenditureRecord(Transaction transaction);
    public Task CancelRequestTransaction(Transaction transaction);
}