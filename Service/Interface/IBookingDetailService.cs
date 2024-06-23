using BusinessObject;

namespace Service.Interface;

public interface IBookingDetailService
{
    public Task<List<BookingDetail>> GetAllBookingDetails();
    public Task<List<BookingDetail>> GetAllBookingDetailsWithBooking(int bookingId);
    public Task<BookingDetail?> AddNewBookingDetails(BookingDetail bookingDetail);
    public Task AddRangeBookingDetails(List<BookingDetail> bookingDetails);
}