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
}