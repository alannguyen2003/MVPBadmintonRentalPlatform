using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class SlotStatusDAO
{
    private readonly AppDbContext _context;
    private static SlotStatusDAO instance;
    
    public SlotStatusDAO()
    {
        _context = new AppDbContext();
    }

    public static SlotStatusDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SlotStatusDAO();
            }
            return instance;
        }
    }

    public async Task<List<SlotStatus>> GetAllSlotStatuses()
    {
        return await _context.SlotStatuses.ToListAsync();
    }

    public async Task AddNewSlotStatus(SlotStatus slotStatus)
    {
        await _context.SlotStatuses.AddAsync(slotStatus);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeSlotStatus(List<SlotStatus> slotStatusList)
    {
        await _context.SlotStatuses.AddRangeAsync(slotStatusList);
        await _context.SaveChangesAsync();
    }
}