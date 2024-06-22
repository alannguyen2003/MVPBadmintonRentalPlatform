using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class BookingStatusRepository : IBookingStatusRepository
{
    public async Task<List<BookingStatus>> GetAllBookingStatus()
    {
        return await BookingStatusDAO.Instance.GetAllBookingStatus();
    }

    public async Task AddNewBookingStatus(BookingStatus bookingStatus)
    {
        await BookingStatusDAO.Instance.AddNewBookingStatus(bookingStatus);
    }

    public async Task AddRangeBookingStatus(List<BookingStatus> bookingStatusList)
    {
        await BookingStatusDAO.Instance.AddRangeBookingStatus(bookingStatusList);
    }
}