using BusinessObject;

namespace Service.Interface;

public interface IServiceCourtService
{
    public Task<List<ServiceCourt>> GetAllServices();
    public Task<List<ServiceCourt>> GetAllSerivcesBasedOnBadmintonCourt(int badmintonCourtId);
    public Task AddServiceCourt(ServiceCourt serviceCourt);
}