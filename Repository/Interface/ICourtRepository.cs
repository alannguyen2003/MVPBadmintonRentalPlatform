using BusinessObject;

namespace Repository.Interface;

public interface ICourtRepository
{
    public Task<List<Court>> GetAllCourts();
    public Task<List<Court>> GetAllCourtsWithBadmintonCourt(int badmintonCourtId);
    public Task AddCourt(Court court);
    public Task AddRangeCourts(List<Court> courts);
    public Task<Court?> GetCourt(int courtId);
}