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

    public async Task AddRangeSlotsForBadmintonCourt(TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration, int courtId)
    {
        await SlotDAO.Instance.AddRangeSlotForBadmintonCourt(startTime, endTime, slotDuration, courtId);
    }
}