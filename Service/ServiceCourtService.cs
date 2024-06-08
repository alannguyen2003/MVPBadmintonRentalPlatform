using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class ServiceCourtService : IServiceCourtService
{
    private readonly IServiceCourtRepository _serviceCourtRepository;

    public ServiceCourtService(IServiceCourtRepository serviceCourtRepository)
    {
        _serviceCourtRepository = serviceCourtRepository;
    }
    
    public async Task<List<ServiceCourt>> GetAllServices()
    {
        return await _serviceCourtRepository.GetAllServices();
    }

    public async Task<List<ServiceCourt>> GetAllSerivcesBasedOnBadmintonCourt(int badmintonCourtId)
    {
        return await _serviceCourtRepository.GetAllServicesBasedOnBadmintonCourt(badmintonCourtId);
    }

    public async Task AddServiceCourt(ServiceCourt serviceCourt)
    {
        await _serviceCourtRepository.AddService(serviceCourt);
    }
}