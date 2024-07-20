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

    public async Task CancelBooking(Booking booking)
    {
        await _bookingRepository.UpdateBooking(booking);
    }

    public async Task<List<BookingDetail>> GetBookingDetails(int bookingId)
    {
        return await _bookingRepository.GetBookingDetails(bookingId);
    }

    public async Task<List<Booking>> GetAllBookingsBeforeNow(int userId)
    {
        return await _bookingRepository.GetAllBookingsBeforeNow(userId);
    }

    public async Task<List<Booking>> GetAllBookingAfterNow(int userId)
    {
        return await _bookingRepository.GetAllBookingAfterNow(userId);
    }

    public async Task<int> GetRevenueByBadmintonCourtIdAndDate(int badmintonCourtId, DateTime date)
    {
        return await _bookingRepository.GetRevenueByDateAndBadmintonCourtId(badmintonCourtId, date);
    }

    public async Task<List<Booking>> GetAllBookingsOfBadmintonCourtBeforeNow(int badmintonCourtId)
    {
        return await _bookingRepository.GetAllBookingsOfBadmintonCourtBeforeNow(badmintonCourtId);
    }

    public async Task UpdateBookingForCourtOwner(Booking booking)
    {
        await _bookingRepository.UpdateBookingForCourtOwner(booking);
    }

    public async Task<List<Booking>> GetAllBookingOfBadmintonCourtByDate(int badmintonCourtId, DateTime date)
    {
        return await _bookingRepository.GetAllBookingOfBadmintonCourtByDate(badmintonCourtId, date);
    }

    public async Task<List<Slot>> GetAllSlotOfBooking(int bookingId)
    {
        return await _bookingRepository.GetAllSlotsOfBooking(bookingId);
    }
}