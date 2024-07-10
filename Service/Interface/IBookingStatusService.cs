using BusinessObject;

namespace Service.Interface;

public interface IBookingStatusService
{
    public Task<List<BookingStatus>> GetAllBookingStatus();

    public Task AddNewBookingStatus(BookingStatus bookingStatus);
    public Task AddRangeBookingStatus(List<BookingStatus> bookingStatusList);
    public Task<BookingStatus?> GetBookingStatus(int bookingStatusId);
}