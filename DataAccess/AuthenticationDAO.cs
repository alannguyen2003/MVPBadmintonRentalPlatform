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

    public async Task<Account?> OwnerRegister(Account account, BadmintonCourt badmintonCourt, List<ServiceCourt> services)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
        badmintonCourt.AccountId = account.Id;
        await _context.BadmintonCourts.AddAsync(badmintonCourt);
        await _context.SaveChangesAsync();
        foreach (var item in services)
        {
            item.BadmintonCourtId = badmintonCourt.Id;
        }
        await ServiceCourtDAO.Instance.AddRangeServiceCourt(services);
        List<Court> courts = new List<Court>();
        for (int i = 1; i <= badmintonCourt.NumberOfCourt; i++)
        {
            courts.Add(new Court()
            {
                BadmintonCourtId = badmintonCourt.Id,
                CourtCode = i.ToString()
            });
        }

        await CourtDAO.Instance.AddRangeCourts(courts);
        return account;
    }

    public async Task AddSlotForBadmintonCourt(int badmintonCourtId)
    {
        
    }
}