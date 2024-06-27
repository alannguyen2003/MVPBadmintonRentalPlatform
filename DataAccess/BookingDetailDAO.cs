using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class BookingDetailDAO
{
    private readonly AppDbContext _context;
    private static BookingDetailDAO instance;
    
    public BookingDetailDAO()
    {
        _context = new AppDbContext();
    }

    public static BookingDetailDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BookingDetailDAO();
            }
            return instance;
        }
    }

    public async Task<BookingDetail> AddNewBookingDetail(BookingDetail bookingDetail)
    {
        await _context.BookingSlots.AddAsync(bookingDetail);
        await _context.SaveChangesAsync();
        return bookingDetail;
    }

    public async Task<List<BookingDetail>> GetAllBookingDetail()
    {
        return await _context.BookingSlots.ToListAsync();
    }

    public async Task<List<BookingDetail>> GetAllBookingDetailsWithBookingId(int bookingId)
    {
        return await _context.BookingSlots
            .Where(bookingDetail => bookingDetail.BookingId == bookingId)
            .ToListAsync();
    }

    public async Task AddRangeBookingDetails(List<BookingDetail> bookingDetails)
    {
        await _context.BookingSlots.AddRangeAsync(bookingDetails);
        await _context.SaveChangesAsync();
    }

    public async Task<BookingDetail?> GetBookingDetailById(int bookingDetailId)
    {
        return await _context.BookingSlots
            .FindAsync(bookingDetailId);
    }
}