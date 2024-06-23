using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class BookingDAO
{
    private readonly AppDbContext _context;
    private static BookingDAO instance;
    
    public BookingDAO()
    {
        _context = new AppDbContext();
    }

    public static BookingDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BookingDAO();
            }
            return instance;
        }
    }

    public async Task<List<Booking>> GetAllBookings()
    {
        return await _context.Bookings.ToListAsync();
    }

    public async Task<Booking?> AddNewBooking(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task<List<Booking>> GetBookingWithPlayerId(int playerId)
    {
        return await _context.Bookings
            .Where(booking => booking.AccountId == playerId)
            .ToListAsync();
    }

    public async Task<Booking?> GetBookingWithId(int bookingId)
    {
        return await _context.Bookings
            .FindAsync(bookingId);
    }
}