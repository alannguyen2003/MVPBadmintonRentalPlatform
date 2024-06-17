using BusinessObject;

namespace Repository.Interface;

public interface IBadmintonCourtRepository
{
    public Task<List<BadmintonCourt>> GetAllBadmintonCourts();
    public Task AddBadmintonCourt(BadmintonCourt badmintonCourt);
    public Task AddRangeBadmintonCourtAsync(List<BadmintonCourt> badmintonCourts);
}