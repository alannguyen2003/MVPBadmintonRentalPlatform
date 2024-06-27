using BusinessObject;
using DataAccess;

namespace Repository.Interface;

public interface IBookingDetailRepository
{
    public Task<List<BookingDetail>> GetAllBookingDetails();
    public Task<List<BookingDetail>> GetAllBookingDetailsWithBooking(int bookingId);
    public Task<BookingDetail?> AddNewBookingDetails(BookingDetail bookingDetail);
    public Task AddRangeBookingDetails(List<BookingDetail> bookingDetails);
    public Task<BookingDetail?> GetBookingDetailById(int bookingDetailId);
}