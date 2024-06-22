using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class CourtDAO
{
    private readonly AppDbContext _context;
    private static CourtDAO instance;
    
    public CourtDAO()
    {
        _context = new AppDbContext();
    }

    public static CourtDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CourtDAO();
            }
            return instance;
        }
    }

    public async Task<List<Court>> GetAllCourts()
    {
        return await _context.Courts
            .Include(badmintonCourt => badmintonCourt.BadmintonCourt)
            .ToListAsync();
    }

    public async Task<List<Court>> GetAllCourtsByBadmintonCourt(int badmintonCourtId)
    {
        return await _context.Courts
            .Where(court => court.BadmintonCourtId == badmintonCourtId)
            .Include(court => court.BadmintonCourt)
            .ToListAsync();
    }

    public async Task AddCourt(Court court)
    {
        await _context.Courts.AddAsync(court);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeCourts(List<Court> courts)
    {
        await _context.Courts.AddRangeAsync(courts);
        await _context.SaveChangesAsync();
    }

    public async Task<Court?> GetCourt(int courtId)
    {
        return await _context.Courts
            .FindAsync(courtId);
    }
}