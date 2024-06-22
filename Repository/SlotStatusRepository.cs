using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class SlotStatusRepository : ISlotStatusRepository
{
    public async Task<List<SlotStatus>> GetAllSlotStatus()
    {
        return await SlotStatusDAO.Instance.GetAllSlotStatuses();
    }

    public async Task AddNewSlotStatus(SlotStatus slotStatus)
    {
        await SlotStatusDAO.Instance.AddNewSlotStatus(slotStatus);
    }

    public async Task AddRangeSlotStatus(List<SlotStatus> slotStatusList)
    {
        await SlotStatusDAO.Instance.AddRangeSlotStatus(slotStatusList);
    }
}