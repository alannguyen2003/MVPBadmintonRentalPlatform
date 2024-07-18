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

    public async Task UpdateBooking(Booking booking)
    {
        _context.ChangeTracker.Clear();
        _context.Attach(booking).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<List<Booking>> GetAllBookingBeforeNow(int userId)
    {
        return await _context.Bookings
            .Where(booking => booking.DateTime < DateTime.Now && booking.AccountId == userId)
            .ToListAsync();
    }

    public async Task<List<Booking>> GetAllBookingAfterNow(int userId)
    {
        return await _context.Bookings
            .Where(booking => booking.DateTime > DateTime.Now && booking.AccountId == userId)
            .ToListAsync();
    }

    public async Task<List<Booking>> GetBookingsByDateAndBadmintonCourtId(int badmintonCourtId, DateTime date)
    {
        return await _context.Bookings
            .Where(booking => booking.BadmintonCourtId == badmintonCourtId &&
                              booking.DateTime.Date == date.Date &&
                              booking.BookingStatusId == 2 || booking.BookingStatusId == 5)
            .ToListAsync();
    }

    public async Task<List<Booking>> GetAllBookingOfBadmintonCourtBeforeNow(int badmintonCourtId)
    {
        return await _context.Bookings
            .Where(booking => booking.BadmintonCourtId == badmintonCourtId &&
                              booking.DateTime < DateTime.Now)
            .ToListAsync();
    }

    public async Task<List<Booking>> GetAllBookingOfBadmintonCourtByDate(int badmintonCourtId, DateTime date)
    {
        return await _context.Bookings
            .Where(booking => booking.BadmintonCourtId == badmintonCourtId &&
                              booking.DateTime == date)
            .ToListAsync();
    }
}