using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessObject;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Interface;
using Service.Interface;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Service;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IConfiguration _configuration;

    public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
    {
        _accountRepository = accountRepository;
        _configuration = configuration;
    }
    public async Task<Account?> GetAccount(string email, string password)
    {
        return await _accountRepository.GetAccount(email, password);
    }

    public async Task<Account?> GetAccount(int userId)
    {
        return await _accountRepository.GetAccount(userId);
    }

    public async Task<string> GenerateJwtToken(Account account)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.Day.ToString()),
            new Claim("UserName", account.FullName),
            new Claim("UserId", account.Id.ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddYears(4),
            signingCredentials: signIn
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task AddNewAccount(Account account)
    {
        await _accountRepository.AddNewAccount(account);
    }

    public async Task<Account?> AddNewAccountAsync(Account account)
    {
        return await _accountRepository.AddNewAccountAsync(account);
    }

    public async Task AddRangeAccountAsync(List<Account> accounts)
    {
        await _accountRepository.AddRangeAccountAsync(accounts);
    }

    public async Task<Account?> RegisterOwner(Account account, BadmintonCourt badmintonCourt)
    {
        return await _accountRepository.RegisterNewOwner(account, badmintonCourt);
    }

    public async Task<List<Account>> GetAllAccounts()
    {
        return await _accountRepository.GetAllAccounts();
    }

    public async Task<List<Account>> GetAccountWithRole(int roleId)
    {
        return await _accountRepository.GetAccontWithRole(roleId);
    }
}