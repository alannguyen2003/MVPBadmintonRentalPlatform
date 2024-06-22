using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class CourtRepository : ICourtRepository
{
    public async Task<List<Court>> GetAllCourts()
    {
        return await CourtDAO.Instance.GetAllCourts();
    }

    public async Task<List<Court>> GetAllCourtsWithBadmintonCourt(int badmintonCourtId)
    {
        return await CourtDAO.Instance.GetAllCourtsByBadmintonCourt(badmintonCourtId);
    }

    public async Task AddCourt(Court court)
    {
        await CourtDAO.Instance.AddCourt(court);
    }

    public async Task AddRangeCourts(List<Court> courts)
    {
        await CourtDAO.Instance.AddRangeCourts(courts);
    }

    public async Task<Court?> GetCourt(int courtId)
    {
        return await CourtDAO.Instance.GetCourt(courtId);
    }
}