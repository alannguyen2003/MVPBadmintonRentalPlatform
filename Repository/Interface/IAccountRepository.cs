﻿using BusinessObject;

namespace Repository.Interface;

public interface IAccountRepository
{
    public Task<Account?> GetAccount(string email, string password);
    public Task<Account?> GetAccount(int userId);
    public Task AddNewAccount(Account account);
    public Task<Account?> AddNewAccountAsync(Account account);
    public Task AddRangeAccountAsync(List<Account> accounts);

    public Task<Account?> RegisterNewOwner(Account account, BadmintonCourt badmintonCourt, List<ServiceCourt> services);
    public Task<List<Account>> GetAllAccounts();
    public Task<List<Account>> GetAccontWithRole(int roleId);
    public Task EditProfileAsync(Account account);
    public Task<int> GetNumberOfPlayer();
    public Task<int> GetNumberOfOwner();
}