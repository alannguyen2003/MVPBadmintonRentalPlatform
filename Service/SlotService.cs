using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class SlotService : ISlotService
{
    private readonly ISlotRepository _slotRepository;

    public SlotService(ISlotRepository slotRepository)
    {
        _slotRepository = slotRepository;
    }
    
    public async Task<List<Slot>> GetAllSlots()
    {
        return await _slotRepository.GetAllSlots();
    }

    public async Task<List<Slot>> GetAllSlotsWithCourt(int courtId)
    {
        return await _slotRepository.GetAllSlotsWithCourt(courtId);
    }

    public async Task<List<Slot>> GetAllSlotsWithBadmintonCourt(int badmintonCourtId)
    {
        return await _slotRepository.GetAllSlotsWithBadmintonCourt(badmintonCourtId);
    }

    public async Task AddRangeSlotsForBadmintonCourt(int hourStart, int minuteStart, int hourEnd, int minuteEnd,
        int courtId)
    {
        await _slotRepository.AddRangeSlotsForBadmintonCourt(new TimeSpan(hourStart, minuteStart, 0),
            new TimeSpan(hourEnd, minuteEnd, 0),
            new TimeSpan(0, 30, 0),
            courtId);
    }
}