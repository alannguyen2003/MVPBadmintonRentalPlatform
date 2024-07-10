using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class BookingStatusService : IBookingStatusService
{
    private readonly IBookingStatusRepository _bookingStatusRepository;

    public BookingStatusService(IBookingStatusRepository bookingStatusRepository)
    {
        _bookingStatusRepository = bookingStatusRepository;
    }
    
    public async Task<List<BookingStatus>> GetAllBookingStatus()
    {
        return await _bookingStatusRepository.GetAllBookingStatus();
    }

    public async Task AddNewBookingStatus(BookingStatus bookingStatus)
    {
        await _bookingStatusRepository.AddNewBookingStatus(bookingStatus);
    }

    public async Task AddRangeBookingStatus(List<BookingStatus> bookingStatusList)
    {
        await _bookingStatusRepository.AddRangeBookingStatus(bookingStatusList);
    }

    public async Task<BookingStatus?> GetBookingStatus(int bookingStatusId)
    {
        return await _bookingStatusRepository.GetBookingStatus(bookingStatusId);
    }
}