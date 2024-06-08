using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ServiceCourtDAO
{
    private readonly AppDbContext _context;
    private static ServiceCourtDAO instance;
    
    public ServiceCourtDAO()
    {
        _context = new AppDbContext();
    }

    public static ServiceCourtDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ServiceCourtDAO();
            }
            return instance;
        }
    }

    public async Task<List<ServiceCourt>> GetAllServices()
    {
        return await _context.ServiceCourts
            .Include(badmintonCourt => badmintonCourt.BadmintonCourt)
            .ToListAsync();
    }

    public async Task<List<ServiceCourt>> GetAllServicesBasedOnBadmintonCourt(int badmintonCourtId)
    {
        return await _context.ServiceCourts
            .Where(service => service.BadmintonCourtId == badmintonCourtId)
            .ToListAsync();
    }

    public async Task AddService(ServiceCourt serviceCourt)
    {
        await _context.ServiceCourts.AddAsync(serviceCourt);
        await _context.SaveChangesAsync();
    }
}