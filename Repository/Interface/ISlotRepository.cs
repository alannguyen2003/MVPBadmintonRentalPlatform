﻿using BusinessObject;

namespace Repository.Interface;

public interface ISlotRepository
{
    public Task<List<Slot>> GetAllSlots();
    public Task<List<Slot>> GetAllSlotsWithCourt(int courtId);
    public Task<List<Slot>> GetAllSlotsWithBadmintonCourt(int badmintonCourtId);
    public Task AddNewSlot(Slot slot);
    public Task AddRangeSlot(List<Slot> slots);
    public Task<List<Slot>> GetSlotsWithDate(DateTime date);
    public Task<List<Slot>> GetSlotByBookingDetails(int bookingDetailId);
}