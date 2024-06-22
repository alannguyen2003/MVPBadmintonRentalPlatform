using BusinessObject;

namespace Repository.Interface;

public interface IBookingStatusRepository
{
    public Task<List<BookingStatus>> GetAllBookingStatus();

    public Task AddNewBookingStatus(BookingStatus bookingStatus);
    public Task AddRangeBookingStatus(List<BookingStatus> bookingStatusList);
}