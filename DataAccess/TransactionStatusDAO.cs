using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class TransactionStatusDAO
{
    private readonly AppDbContext _context;
    private static TransactionStatusDAO instance;
    
    public TransactionStatusDAO()
    {
        _context = new AppDbContext();
    }

    public static TransactionStatusDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TransactionStatusDAO();
            }
            return instance;
        }
    }

    public async Task<List<TransactionStatus>> GetAllTransactionStatus()
    {
        return await _context.TransactionStatuses.ToListAsync();
    }

    public async Task AddNewTransactionStatus(TransactionStatus transactionStatus)
    {
        await _context.TransactionStatuses.AddAsync(transactionStatus);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeTransactionStatus(List<TransactionStatus> transactionStatusList)
    {
        await _context.TransactionStatuses.AddRangeAsync(transactionStatusList);
        await _context.SaveChangesAsync();
    }
    
}