using BusinessObject;

namespace Service.Interface;

public interface ICourtService
{
    public Task<List<Court>> GetAllCourts();
    public Task<List<Court>> GetAllCourtsWithBadmintonCourt(int badmintonCourtId);
    public Task AddCourt(Court court);
    public Task AddRangeCourts(List<Court> courts);
    public Task<Court?> GetCourt(int courtId);
}