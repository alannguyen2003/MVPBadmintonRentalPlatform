using BusinessObject;

namespace Repository.Interface;

public interface IBadmintonCourtRepository
{
    public Task<List<BadmintonCourt>> GetAllBadmintonCourts();
    public Task AddBadmintonCourt(BadmintonCourt badmintonCourt);
    public Task AddRangeBadmintonCourtAsync(List<BadmintonCourt> badmintonCourts);
    public Task<BadmintonCourt?> GetBadmintonCourtWithOwner(int ownerId);
    public Task<BadmintonCourt?> GetBadmintonCourt(int badmintonCourtId);
    public Task<List<Slot>> GetAllSlotsOfBadmintonCourt(int badmintonCourt);
}