using BusinessObject;

namespace Repository.Interface;

public interface IServiceCourtRepository
{
    public Task<List<ServiceCourt>> GetAllServices();
    public Task<List<ServiceCourt>> GetAllServicesBasedOnBadmintonCourt(int badmintonCourtId);
    public Task AddService(ServiceCourt serviceCourt);
}