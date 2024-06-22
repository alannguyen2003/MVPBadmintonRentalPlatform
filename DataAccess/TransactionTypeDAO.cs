using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class TransactionTypeDAO
{
    private readonly AppDbContext _context;
    private static TransactionTypeDAO instance;
    
    public TransactionTypeDAO()
    {
        _context = new AppDbContext();
    }

    public static TransactionTypeDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TransactionTypeDAO();
            }
            return instance;
        }
    }
    
    public async Task<List<TransactionType>> GetAllTransactionTypes()
    {
        return await _context.TransactionTypes.ToListAsync();
    }

    public async Task AddNewTransactionType(TransactionType transactionType)
    {
        await _context.TransactionTypes.AddAsync(transactionType);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeTransactionType(List<TransactionType> transactionTypes)
    {
        await _context.TransactionTypes.AddRangeAsync(transactionTypes);
        await _context.SaveChangesAsync();
    }
}