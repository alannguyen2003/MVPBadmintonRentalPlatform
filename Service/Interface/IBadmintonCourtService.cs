﻿using BusinessObject;

namespace Service.Interface;

public interface IBadmintonCourtService
{
    public Task<List<BadmintonCourt>> GetAllBadmintonCourts();
    public Task AddBadmintonCourt(BadmintonCourt badmintonCourt);
}