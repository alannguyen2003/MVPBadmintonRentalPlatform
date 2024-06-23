using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class BookingDetailService : IBookingDetailService
{
    private readonly IBookingDetailRepository _bookingDetailRepository;

    public BookingDetailService(IBookingDetailRepository bookingDetailRepository)
    {
        _bookingDetailRepository = bookingDetailRepository;
    }
    
    public async Task<List<BookingDetail>> GetAllBookingDetails()
    {
        return await _bookingDetailRepository.GetAllBookingDetails();
    }

    public async Task<List<BookingDetail>> GetAllBookingDetailsWithBooking(int bookingId)
    {
        return await _bookingDetailRepository.GetAllBookingDetailsWithBooking(bookingId);
    }

    public async Task<BookingDetail?> AddNewBookingDetails(BookingDetail bookingDetail)
    {
        return await _bookingDetailRepository.AddNewBookingDetails(bookingDetail);
    }

    public async Task AddRangeBookingDetails(List<BookingDetail> bookingDetails)
    {
        await _bookingDetailRepository.AddRangeBookingDetails(bookingDetails);
    }
}