using BusinessObject;
using DataTransfer.Response;

namespace Service.Interface;

public interface IBadmintonCourtService
{
    public Task<List<BadmintonCourt>> GetAllBadmintonCourts();
    public Task AddBadmintonCourt(BadmintonCourt badmintonCourt);
    public Task AddRangeBadmintonCourt(List<BadmintonCourt> badmintonCourts);
    public Task<BadmintonCourt?> GetBadmintonCourtWithOwnerId(int ownerId);
    public Task<BadmintonCourt?> GetBadmintonCourt(int badmintonCourt);
    public Task<List<Slot>> GetAllSlotsOfBadmintonCourt(int badmintonCourtId);
    public Task<List<BadmintonCourt>> SearchBadmintonCourtByName(string search);
}