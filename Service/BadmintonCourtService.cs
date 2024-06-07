using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class BadmintonCourtService : IBadmintonCourtService
{
    private readonly IBadmintonCourtRepository _badmintonCourtRepository;

    public BadmintonCourtService(IBadmintonCourtRepository badmintonCourtRepository)
    {
        _badmintonCourtRepository = badmintonCourtRepository;
    }
    public async Task<List<BadmintonCourt>> GetAllBadmintonCourts()
    {
        return await _badmintonCourtRepository.GetAllBadmintonCourts();
    }

    public async Task AddBadmintonCourt(BadmintonCourt badmintonCourt)
    {
        await _badmintonCourtRepository.AddBadmintonCourt(badmintonCourt);
    }
}