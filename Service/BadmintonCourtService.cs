﻿using BusinessObject;
using DataTransfer.Response;
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

    public async Task AddRangeBadmintonCourt(List<BadmintonCourt> badmintonCourts)
    {
        await _badmintonCourtRepository.AddRangeBadmintonCourtAsync(badmintonCourts);
    }

    public async Task<BadmintonCourt?> GetBadmintonCourtWithOwnerId(int ownerId)
    {
        return await _badmintonCourtRepository.GetBadmintonCourtWithOwner(ownerId);
    }

    public async Task<BadmintonCourt?> GetBadmintonCourt(int badmintonCourt)
    {
        return await _badmintonCourtRepository.GetBadmintonCourt(badmintonCourt);
    }

    public async Task<List<Slot>> GetAllSlotsOfBadmintonCourt(int badmintonCourtId)
    {
        return await _badmintonCourtRepository.GetAllSlotsOfBadmintonCourt(badmintonCourtId);
    }

    public async Task<List<BadmintonCourt>> SearchBadmintonCourtByName(string search)
    {
        return await _badmintonCourtRepository.SearchBadmintonCourtByName(search);
    }
}