using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public async Task<List<Transaction>> GetAllTransaction()
    {
        return await _transactionRepository.GetAllTransaction();
    }

    public async Task<List<Transaction>> GetAllTransactionByAccount(int accountId)
    {
        return await _transactionRepository.GetAllTransactionByAccount(accountId);
    }

    public async Task<List<Transaction>> GetAllTransactionByType(int transactionTypeId)
    {
        return await _transactionRepository.GetAllTransactionByType(transactionTypeId);
    }

    public async Task<List<Transaction>> GetAllTransactionByStatus(int transactionStatusId)
    {
        return await _transactionRepository.GetAllTransactionByStatus(transactionStatusId);
    }

    public async Task AddNewTransaction(Transaction transaction)
    {
        await _transactionRepository.AddNewTransaction(transaction);
    }

    public async Task AddRangeTransaction(List<Transaction> transactions)
    {
        await _transactionRepository.AddRangeTransaction(transactions);
    }

    public async Task<Transaction?> GetTransaction(int transactionId)
    {
        return await _transactionRepository.GetTransaction(transactionId);
    }

    public async Task ApproveTransaction(Transaction transaction)
    {
        await _transactionRepository.ApproveTransaction(transaction);
    }

    public async Task RejectTransaction(Transaction transaction)
    {
        await _transactionRepository.RejectTransaction(transaction);
    }

    public async Task AddNewExpenditureRecord(Transaction transaction)
    {
        await _transactionRepository.AddNewExpenditureRecord(transaction);
    }
}