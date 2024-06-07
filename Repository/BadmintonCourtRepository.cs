using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class BadmintonCourtRepository : IBadmintonCourtRepository
{
    public async Task<List<BadmintonCourt>> GetAllBadmintonCourts()
    {
        return await BadmintonCourtDAO.Instance.GetAllBadmintonCourts();
    }

    public async Task AddBadmintonCourt(BadmintonCourt badmintonCourt)
    {
        await BadmintonCourtDAO.Instance.AddBadmintonCourt(badmintonCourt);
    }
}