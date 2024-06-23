using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class BookingDetailRepository : IBookingDetailRepository
{
    public async Task<List<BookingDetail>> GetAllBookingDetails()
    {
        return await BookingDetailDAO.Instance.GetAllBookingDetail();
    }

    public async Task<List<BookingDetail>> GetAllBookingDetailsWithBooking(int bookingId)
    {
        return await BookingDetailDAO.Instance.GetAllBookingDetailsWithBookingId(bookingId);
    }

    public async Task<BookingDetail?> AddNewBookingDetails(BookingDetail bookingDetail)
    {
        return await BookingDetailDAO.Instance.AddNewBookingDetail(bookingDetail);
    }

    public async Task AddRangeBookingDetails(List<BookingDetail> bookingDetails)
    {
        await BookingDetailDAO.Instance.AddRangeBookingDetails(bookingDetails);
    }
}