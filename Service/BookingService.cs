using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }
    
    public async Task<List<Booking>> GetAllBookings()
    {
        return await _bookingRepository.GetAllBookings();
    }

    public async Task<Booking?> AddNewBookingAsync(Booking booking)
    {
        return await _bookingRepository.AddNewBookingAsync(booking);
    }

    public async Task<List<Booking>> GetBookingsWithPlayerId(int playerId)
    {
        return await _bookingRepository.GetBookingsWithPlayerId(playerId);
    }

    public async Task<Booking?> GetBookingWithId(int bookingId)
    {
        return await _bookingRepository.GetBookingWithId(bookingId);
    }
}