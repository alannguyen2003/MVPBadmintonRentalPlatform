using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class SlotStatusService : ISlotStatusService
{
    private readonly ISlotStatusRepository _slotStatusRepository;

    public SlotStatusService(ISlotStatusRepository slotStatusRepository)
    {
        _slotStatusRepository = slotStatusRepository;
    }
    
    public async Task<List<SlotStatus>> GetAllSlotStatus()
    {
        return await _slotStatusRepository.GetAllSlotStatus();
    }

    public async Task AddNewSlotStatus(SlotStatus slotStatus)
    {
        await _slotStatusRepository.AddNewSlotStatus(slotStatus);
    }

    public async Task AddRangeSlotStatus(List<SlotStatus> slotStatusList)
    {
        await _slotStatusRepository.AddRangeSlotStatus(slotStatusList);
    }
}