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

    public async Task AddRangeBadmintonCourtAsync(List<BadmintonCourt> badmintonCourts)
    {
        await BadmintonCourtDAO.Instance.AddRangeBadmintonCourt(badmintonCourts);
    }

    public async Task<BadmintonCourt?> GetBadmintonCourtWithOwner(int ownerId)
    {
        return await BadmintonCourtDAO.Instance.GetBadmintonCourtWithOwnerId(ownerId);
    }

    public async Task<BadmintonCourt?> GetBadmintonCourt(int badmintonCourtId)
    {
        return await BadmintonCourtDAO.Instance.GetBadmintonCourt(badmintonCourtId);
    }

    public async Task<List<Slot>> GetAllSlotsOfBadmintonCourt(int badmintonCourt)
    {
        return await BadmintonCourtDAO.Instance.GetAllSlotsOfBadmintonCourt(badmintonCourt);
    }

    public async Task<List<BadmintonCourt>> SearchBadmintonCourtByName(string search)
    {
        return await BadmintonCourtDAO.Instance.SearchBadmintonCourtByName(search);
    }
}