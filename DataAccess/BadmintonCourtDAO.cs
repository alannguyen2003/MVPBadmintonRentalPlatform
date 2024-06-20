using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class BadmintonCourtDAO
{
    private readonly AppDbContext _context;
    private static BadmintonCourtDAO instance;
    
    public BadmintonCourtDAO()
    {
        _context = new AppDbContext();
    }

    public static BadmintonCourtDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BadmintonCourtDAO();
            }
            return instance;
        }
    }

    public async Task<List<BadmintonCourt>> GetAllBadmintonCourts()
    {
        return await _context.BadmintonCourts
            .ToListAsync();
    }

    public async Task AddBadmintonCourt(BadmintonCourt badmintonCourt)
    {
        await _context.BadmintonCourts.AddAsync(badmintonCourt);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeBadmintonCourt(List<BadmintonCourt> badmintonCourts)
    {
        await _context.BadmintonCourts.AddRangeAsync(badmintonCourts);
        await _context.SaveChangesAsync();
    }

    public async Task<BadmintonCourt?> GetBadmintonCourtWithOwnerId(int ownerId)
    {
        return await _context.BadmintonCourts
            .FirstOrDefaultAsync(court => court.AccountId == ownerId);
    }

    public async Task<BadmintonCourt?> GetBadmintonCourt(int badmintonCourtId)
    {
        return await _context.BadmintonCourts
            .FindAsync(badmintonCourtId);
    }

    public async Task<List<Slot>> GetAllSlotsOfBadmintonCourt(int badmintonCourtId)
    {
        var courts = await _context.Courts
            .Where(court => court.BadmintonCourtId == badmintonCourtId)
            .ToListAsync();
        List<Slot> slots = new List<Slot>();
        foreach (var court in courts)
        {
            slots.AddRange(await _context.Slots
                .Where(slot => slot.CourtId == court.Id)
                .ToListAsync());
        }
        return slots;
    }
}