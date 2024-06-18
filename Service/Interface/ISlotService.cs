using BusinessObject;

namespace Service.Interface;

public interface ISlotService
{
    public Task<List<Slot>> GetAllSlots();
    public Task<List<Slot>> GetAllSlotsWithCourt(int courtId);
    public Task<List<Slot>> GetAllSlotsWithBadmintonCourt(int badmintonCourtId);

    public Task AddRangeSlotsForBadmintonCourt(int hourStart, int minuteStart, int hourEnd, int minuteEnd,
        int courtId);
}