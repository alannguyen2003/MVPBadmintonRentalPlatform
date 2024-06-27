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
            if (account.Balance >= booking.Price)
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

    public async Task UpdateBooking(Booking booking)
    {
        booking.BookingStatusId = 4;
        var user = await AccountDAO.Instance.GetAccount(booking.AccountId);
        user.Balance += booking.Price;
        await AccountDAO.Instance.EditProfile(user);
        await BookingDAO.Instance.UpdateBooking(booking);
    }

    public async Task<List<BookingDetail>> GetBookingDetails(int bookingId)
    {
        return await BookingDetailDAO.Instance.GetAllBookingDetailsWithBookingId(bookingId);
    }

    public async Task<List<Booking>> GetAllBookingsBeforeNow(int userId)
    {
        return await BookingDAO.Instance.GetAllBookingBeforeNow(userId);
    }

    public async Task<List<Booking>> GetAllBookingAfterNow(int userId)
    {
        return await BookingDAO.Instance.GetAllBookingAfterNow(userId);
    }
}