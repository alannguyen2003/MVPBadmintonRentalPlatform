using BusinessObject;

namespace Service.Interface;

public interface IServiceCourtService
{
    public Task<List<ServiceCourt>> GetAllServices();
    public Task<List<ServiceCourt>> GetAllSerivcesBasedOnBadmintonCourt(int badmintonCourtId);
    public Task AddServiceCourt(ServiceCourt serviceCourt);
    public Task AddRangeServiceCourt(List<ServiceCourt> listService);
    public void GenerateTimeSlot(TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration, out List<int> hours, out List<int> minutes);
}