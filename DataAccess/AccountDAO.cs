﻿using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AccountDAO
{
    private readonly AppDbContext _context;
    private static AccountDAO instance;
    
    public AccountDAO()
    {
        _context = new AppDbContext();
    }

    public static AccountDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AccountDAO();
            }
            return instance;
        }
    }

    public async Task<Account?> GetAccount(string email, string password)
    {
        return await _context.Accounts
            .FirstOrDefaultAsync(account => account.Email.Equals(email) &&
                                            account.Password.Equals(password));
    }

    public async Task AddNewAccount(Account account)
    {
        var accountContext = await _context.Accounts.FirstOrDefaultAsync(account => account.Email.Equals(account.Email));
        if (accountContext == null)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Account?> AddNewAccountAsync(Account account)
    {
        var accountContext = await _context.Accounts
            .FirstOrDefaultAsync(acc => acc.Email.Equals(account.Email));
        if (accountContext == null)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
        else
        {
            return null;
        }
        return account;
    }

    public async Task<List<Account>> GetAllAccount()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account?> GetAccount(int userId)
    {
        return await _context.Accounts.FindAsync(userId);
    }

    public async Task<List<Account>> GetAccountWithRole(int roleId)
    {
        return await _context.Accounts
            .Where(account => account.RoleId == roleId)
            .ToListAsync();
    }

    public async Task AddRangeAccountAsync(List<Account> accounts)
    {
        await _context.Accounts.AddRangeAsync(accounts);
        await _context.SaveChangesAsync();
    }

    public async Task EditProfile(Account account)
    {
        _context.Attach(account).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetNumberOfPlayer()
    {
        return await _context.Accounts
            .CountAsync(account => account.RoleId == 1);
    }

    public async Task<int> GetNumberOfOwner()
    {
        return await _context.Accounts
            .CountAsync(account => account.RoleId == 2);
    }
}