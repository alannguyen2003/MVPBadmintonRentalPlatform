using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AccountDAO
{
    private readonly AppDbContext _context;
    private static AccountDAO instance;
    
    public AccountDAO()
    {
        _context = new AppDbContext();
    }

    public static AccountDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AccountDAO();
            }
            return instance;
        }
    }

    public async Task<Account?> GetAccount(string email, string password)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(account => account.Email.Equals(email) &&
                                            account.Password.Equals(password));
    }

    public async Task AddNewAccount(Account account)
    {
        var accountContext = await _context.Accounts.FirstOrDefaultAsync(account => account.Email.Equals(account.Email));
        if (accountContext == null)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Account?> AddNewAccountAsync(Account account)
    {
        var accountContext = await _context.Accounts
            .FirstOrDefaultAsync(acc => acc.Email.Equals(account.Email));
        if (accountContext == null)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
        else
        {
            return null;
        }
        return account;
    }

    public async Task<List<Account>> GetAllAccount()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account?> GetAccount(int userId)
    {
        return await _context.Accounts.FindAsync(userId);
    }
}