﻿using BusinessObject;

namespace Service.Interface;

public interface IBookingService
{
    public Task<List<Booking>> GetAllBookings();
    public Task<Booking?> AddNewBookingAsync(Booking booking);
    public Task<List<Booking>> GetBookingsWithPlayerId(int playerId);
    public Task<Booking?> GetBookingWithId(int bookingId);
    public Task CancelBooking(Booking booking);
    public Task<List<BookingDetail>> GetBookingDetails(int bookingId);
    public Task<List<Booking>> GetAllBookingsBeforeNow(int userId);
    public Task<List<Booking>> GetAllBookingAfterNow(int userId);
    public Task<int> GetRevenueByBadmintonCourtIdAndDate(int badmintonCourtId, DateTime date);
    public Task<List<Booking>> GetAllBookingsOfBadmintonCourtBeforeNow(int badmintonCourtId);
    public Task UpdateBookingForCourtOwner(Booking booking);
    public Task<List<Booking>> GetAllBookingOfBadmintonCourtByDate(int badmintonCourtId, DateTime date);
    public Task<List<Slot>> GetAllSlotOfBooking(int bookingId);
}