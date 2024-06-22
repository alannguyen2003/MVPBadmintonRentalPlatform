using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class BookingStatusDAO
{
    private readonly AppDbContext _context;
    private static BookingStatusDAO instance;
    
    public BookingStatusDAO()
    {
        _context = new AppDbContext();
    }

    public static BookingStatusDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BookingStatusDAO();
            }
            return instance;
        }
    }
    
    public async Task<List<BookingStatus>> GetAllBookingStatus()
    {
        return await _context.BookingStatuses.ToListAsync();
    }

    public async Task AddNewBookingStatus(BookingStatus bookingStatus)
    {
        await _context.BookingStatuses.AddAsync(bookingStatus);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeBookingStatus(List<BookingStatus> bookingStatusList)
    {
        await _context.BookingStatuses.AddRangeAsync(bookingStatusList);
        await _context.SaveChangesAsync();
    }
}