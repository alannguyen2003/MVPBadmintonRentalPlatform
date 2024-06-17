using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class ServiceCourtRepository : IServiceCourtRepository
{
    public async Task<List<ServiceCourt>> GetAllServices()
    {
        return await ServiceCourtDAO.Instance.GetAllServices();
    }

    public async Task<List<ServiceCourt>> GetAllServicesBasedOnBadmintonCourt(int badmintonCourtId)
    {
        return await ServiceCourtDAO.Instance.GetAllServicesBasedOnBadmintonCourt(badmintonCourtId);
    }

    public async Task AddService(ServiceCourt serviceCourt)
    {
        await ServiceCourtDAO.Instance.AddService(serviceCourt);
    }

    public async Task AddRangeService(List<ServiceCourt> listService)
    {
        await ServiceCourtDAO.Instance.AddRangeServiceCourt(listService);
    }
}