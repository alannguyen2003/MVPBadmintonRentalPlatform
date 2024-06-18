using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class BankDAO
{
    private readonly AppDbContext _context;
    private static BankDAO instance;
    
    public BankDAO()
    {
        _context = new AppDbContext();
    }

    public static BankDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BankDAO();
            }
            return instance;
        }
    }

    public async Task<List<Bank>> GetAllBanks()
    {
        return await _context.Banks.ToListAsync();
    }

    public async Task AddNewBank(Bank bank)
    {
        await _context.Banks.AddAsync(bank);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeBanks(List<Bank> banks)
    {
        await _context.Banks.AddRangeAsync(banks);
        await _context.SaveChangesAsync();
    }
}