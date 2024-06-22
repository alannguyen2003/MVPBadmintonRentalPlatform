using BusinessObject;

namespace Repository.Interface;

public interface ISlotStatusRepository
{
    public Task<List<SlotStatus>> GetAllSlotStatus();
    public Task AddNewSlotStatus(SlotStatus slotStatus);
    public Task AddRangeSlotStatus(List<SlotStatus> slotStatusList);
}