using BusinessObject;

namespace Service.Interface;

public interface ISlotStatusService
{
    public Task<List<SlotStatus>> GetAllSlotStatus();
    public Task AddNewSlotStatus(SlotStatus slotStatus);
    public Task AddRangeSlotStatus(List<SlotStatus> slotStatusList);
}