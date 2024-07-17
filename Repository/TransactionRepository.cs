using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class TransactionRepository : ITransactionRepository
{
    public async Task<List<Transaction>> GetAllTransaction()
    {
        return await TransactionDAO.Instance.GetAllTransaction();
    }

    public async Task<List<Transaction>> GetAllTransactionByAccount(int accountId)
    {
        return await TransactionDAO.Instance.GetAllTransactionByAccount(accountId);
    }

    public async Task<List<Transaction>> GetAllTransactionByType(int transactionTypeId)
    {
        return await TransactionDAO.Instance.GetAllTransactionByType(transactionTypeId);
    }

    public async Task<List<Transaction>> GetAllTransactionByStatus(int transactionStatusId)
    {
        return await TransactionDAO.Instance.GetAllTransactionByStatus(transactionStatusId);
    }

    public async Task AddNewTransaction(Transaction transaction)
    {
        await TransactionDAO.Instance.AddNewTransaction(transaction);
    }

    public async Task AddRangeTransaction(List<Transaction> transactions)
    {
        await TransactionDAO.Instance.AddRangeTransaction(transactions);
    }

    public async Task<Transaction?> GetTransaction(int transactionId)
    {
        return await TransactionDAO.Instance.GetTransaction(transactionId);
    }

    public async Task ApproveTransaction(Transaction transaction)
    {
        transaction.TransactionStatusId = 2;
        var account = await AccountDAO.Instance.GetAccount(transaction.AccountId);
        if (transaction.TransactionTypeId == 1)
        {
            account.Balance += transaction.Amount;
        }
        else if (transaction.TransactionTypeId == 2)
        {
            account.Balance -= transaction.Amount;
        }
        await AccountDAO.Instance.EditProfile(account);
        await TransactionDAO.Instance.UpdateTransaction(transaction);
    }

    public async Task RejectTransaction(Transaction transaction)
    {
        transaction.TransactionStatusId = 3;
        await TransactionDAO.Instance.UpdateTransaction(transaction);
    }

    public async Task AddNewExpenditureRecord(Transaction transaction)
    {
        transaction.TransactionStatusId = 2;
        await TransactionDAO.Instance.AddNewTransaction(transaction);
    }

    public async Task CancelRequestTransaction(Transaction transaction)
    {
        transaction.TransactionStatusId = 3;
        await TransactionDAO.Instance.UpdateTransaction(transaction);
    }
}