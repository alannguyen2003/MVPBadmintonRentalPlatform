using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class SlotRepository : ISlotRepository
{
    public async Task<List<Slot>> GetAllSlots()
    {
        return await SlotDAO.Instance.GetAllSlots();
    }

    public async Task<List<Slot>> GetAllSlotsWithCourt(int courtId)
    {
        return await SlotDAO.Instance.GetAllSlotsOfCourt(courtId);
    }

    public async Task<List<Slot>> GetAllSlotsWithBadmintonCourt(int badmintonCourtId)
    {
        return await SlotDAO.Instance.GetAllSlotsOfBadmintonCourt(badmintonCourtId);
    }

    public async Task AddNewSlot(Slot slot)
    {
        await SlotDAO.Instance.AddNewSlot(slot);
    }

    public async Task AddRangeSlot(List<Slot> slots)
    {
        await SlotDAO.Instance.AddRangeSlot(slots);
    }

    public async Task<List<Slot>> GetSlotsWithDate(DateTime date)
    {
        return await SlotDAO.Instance.GetSlotByDateTime(date);
    }

    public async Task<List<Slot>> GetSlotByBookingDetails(int bookingDetailId)
    {
        return await SlotDAO.Instance.GetAllSlotByBookingDetails(bookingDetailId);
    }
}