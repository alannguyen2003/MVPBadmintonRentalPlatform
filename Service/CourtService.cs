using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class CourtService : ICourtService
{
    private readonly ICourtRepository _courtRepository;

    public CourtService(ICourtRepository courtRepository)
    {
        _courtRepository = courtRepository;
    }
    public async Task<List<Court>> GetAllCourts()
    {
        return await _courtRepository.GetAllCourts();
    }

    public async Task<List<Court>> GetAllCourtsWithBadmintonCourt(int badmintonCourtId)
    {
        return await _courtRepository.GetAllCourtsWithBadmintonCourt(badmintonCourtId);
    }

    public async Task AddCourt(Court court)
    {
        await _courtRepository.AddCourt(court);
    }

    public async Task AddRangeCourts(List<Court> courts)
    {
        await _courtRepository.AddRangeCourts(courts);
    }

    public async Task<Court?> GetCourt(int courtId)
    {
        return await _courtRepository.GetCourt(courtId);
    }
}