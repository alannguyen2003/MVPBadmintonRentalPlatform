using BusinessObject;

namespace Service.Interface;

public interface IBookingService
{
    public Task<List<Booking>> GetAllBookings();
    public Task AddNewBookingAsync(Booking booking);
    public Task<List<Booking>> GetBookingsWithPlayerId(int playerId);
    public Task<Booking?> GetBookingWithId(int bookingId);
}