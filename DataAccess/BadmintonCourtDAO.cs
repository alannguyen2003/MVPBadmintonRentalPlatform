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
}