using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class TransactionDAO
{
    private readonly AppDbContext _context;
    private static TransactionDAO instance;
    
    public TransactionDAO()
    {
        _context = new AppDbContext();
    }

    public static TransactionDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TransactionDAO();
            }
            return instance;
        }
    }

    public async Task<List<Transaction>> GetAllTransaction()
    {
        return await _context.Transactions
            .Include(account => account.Account)
            .Include(status => status.TransactionStatus)
            .Include(type => type.TransactionType)
            .ToListAsync();
    }

    public async Task<List<Transaction>> GetAllTransactionByAccount(int accountId)
    {
        return await _context.Transactions
            .Where(transaction => transaction.AccountId == accountId)
            .Include(account => account.Account)
            .Include(status => status.TransactionStatus)
            .Include(type => type.TransactionType)
            .ToListAsync();
    }

    public async Task<List<Transaction>> GetAllTransactionByType(int transactionTypeId)
    {
        return await _context.Transactions
            .Where(transaction => transaction.TransactionTypeId == transactionTypeId)
            .Include(account => account.Account)
            .Include(status => status.TransactionStatus)
            .Include(type => type.TransactionType)
            .ToListAsync();
    }

    public async Task<List<Transaction>> GetAllTransactionByStatus(int transactionStatusId)
    {
        return await _context.Transactions
            .Where(transaction => transaction.TransactionStatusId == transactionStatusId)
            .Include(account => account.Account)
            .Include(status => status.TransactionStatus)
            .Include(type => type.TransactionType)
            .ToListAsync();
    }

    public async Task AddNewTransaction(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeTransaction(List<Transaction> transactions)
    {
        await _context.Transactions.AddRangeAsync(transactions);
        await _context.SaveChangesAsync();
    }

    public async Task<Transaction?> GetTransaction(int transactionId)
    {
        return await _context.Transactions
            .Include(account => account.Account)
            .Include(status => status.TransactionStatus)
            .Include(type => type.TransactionType)
            .FirstAsync(transaction => transaction.Id == transactionId);
    }

    public async Task UpdateTransaction(Transaction transaction)
    {
        _context.Attach(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}