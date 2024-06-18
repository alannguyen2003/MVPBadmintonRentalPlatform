using BusinessObject;

namespace Repository.Interface;

public interface ISlotRepository
{
    public Task<List<Slot>> GetAllSlots();
    public Task<List<Slot>> GetAllSlotsWithCourt(int courtId);
    public Task<List<Slot>> GetAllSlotsWithBadmintonCourt(int badmintonCourtId);

    public Task AddRangeSlotsForBadmintonCourt(TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration,
        int courtId);
}