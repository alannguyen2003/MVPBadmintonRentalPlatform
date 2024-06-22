using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class BookingRepository : IBookingRepository
{
    public async Task<List<Booking>> GetAllBookings()
    {
        return await BookingDAO.Instance.GetAllBookings();
    }

    public async Task AddNewBookingAsync(Booking booking)
    {
        await BookingDAO.Instance.AddNewBooking(booking);
    }

    public async Task<List<Booking>> GetBookingsWithPlayerId(int playerId)
    {
        return await BookingDAO.Instance.GetBookingWithPlayerId(playerId);
    }

    public async Task<Booking?> GetBookingWithId(int bookingId)
    {
        return await BookingDAO.Instance.GetBookingWithId(bookingId);
    }
}