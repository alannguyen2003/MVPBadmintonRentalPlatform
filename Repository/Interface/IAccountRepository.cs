﻿using BusinessObject;

namespace Repository.Interface;

public interface IAccountRepository
{
    public Task<Account?> GetAccount(string email, string password);
    public Task AddNewAccount(Account account);
    public Task<Account?> AddNewAccountAsync(Account account);
    public Task<Account?> RegisterNewOwner(Account account, BadmintonCourt badmintonCourt);
    public Task<List<Account>> GetAllAccounts();
}