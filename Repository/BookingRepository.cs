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

    public async Task<Booking?> AddNewBookingAsync(Booking booking)
    {
        try
        {
            var account = await AccountDAO.Instance.GetAccount(booking.AccountId);
            if (account.Balance < booking.Price)
            {
                account.Balance -= booking.Price;
            }
            else await AccountDAO.Instance.EditProfile(account);
            return await BookingDAO.Instance.AddNewBooking(booking);
        }
        catch (Exception ex)
        {
            return null;
        }
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