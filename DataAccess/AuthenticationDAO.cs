using BusinessObject;

namespace DataAccess;

public class AuthenticationDAO
{
    private readonly AppDbContext _context;
    private static AuthenticationDAO instance;
    
    public AuthenticationDAO()
    {
        _context = new AppDbContext();
    }

    public static AuthenticationDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AuthenticationDAO();
            }
            return instance;
        }
    }

    public async Task<Account?> OwnerRegister(Account account, BadmintonCourt badmintonCourt)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
        badmintonCourt.AccountId = account.Id;
        await _context.BadmintonCourts.AddAsync(badmintonCourt);
        await _context.SaveChangesAsync();
        return account;
    }
}