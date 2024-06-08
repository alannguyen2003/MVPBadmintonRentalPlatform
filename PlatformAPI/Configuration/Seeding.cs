using BusinessObject;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace PlatformAPI.Configuration;

public class Seeding
{
    private readonly IAccountService _accountService;
    private readonly IRoleService _roleService;
    private readonly IBadmintonCourtService _badmintonCourtService;
    private readonly IServiceCourtService _serviceCourtService;
    private readonly AppDbContext _context;

    public Seeding(IAccountService accountService, IRoleService roleService,
        IBadmintonCourtService badmintonCourtService, IServiceCourtService serviceCourtService)
    {
        _accountService = accountService;
        _context = new AppDbContext();
        _roleService = roleService;
        _badmintonCourtService = badmintonCourtService;
        _serviceCourtService = serviceCourtService;
    }

    public async Task MigrateDatabaseAsync()
    {
        await _context.Database.MigrateAsync();
    }

    public async Task SeedBadmintonCourtService()
    {
        if (await _context.ServiceCourts.AnyAsync())
        {
            return;
        }

        var serviceCourts = new List<ServiceCourt>()
        {
            new ServiceCourt()
            {
                ServiceName = "Wifi",
                BadmintonCourtId = 1
            },
            new ServiceCourt()
            {
                ServiceName = "Tổ chức giải đấu",
                BadmintonCourtId = 1
            },
            new ServiceCourt()
            {
                ServiceName = "Giữ xe miễn phí",
                BadmintonCourtId = 1
            },
            new ServiceCourt()
            {
                ServiceName = "Canteen",
                BadmintonCourtId = 1
            },
            new ServiceCourt()
            {
                ServiceName = "Wifi",
                BadmintonCourtId = 2
            },
            new ServiceCourt()
            {
                ServiceName = "Tổ chức giải đấu",
                BadmintonCourtId = 2
            },
            new ServiceCourt()
            {
                ServiceName = "Giữ xe miễn phí",
                BadmintonCourtId = 2
            },
            new ServiceCourt()
            {
                ServiceName = "Canteen",
                BadmintonCourtId = 2
            },
            new ServiceCourt()
            {
                ServiceName = "Wifi",
                BadmintonCourtId = 3
            },
            new ServiceCourt()
            {
                ServiceName = "Tổ chức giải đấu",
                BadmintonCourtId = 3
            },
            new ServiceCourt()
            {
                ServiceName = "Giữ xe miễn phí",
                BadmintonCourtId = 3
            },
            new ServiceCourt()
            {
                ServiceName = "Canteen",
                BadmintonCourtId = 3
            },
            new ServiceCourt()
            {
                ServiceName = "Cafe",
                BadmintonCourtId = 3
            }
        };
        foreach (var item in serviceCourts)
        {
            await _serviceCourtService.AddServiceCourt(item);
        }
    }

    public async Task SeedBadmintonCourt()
    {
        if (await _context.BadmintonCourts.AnyAsync())
        {
            return;
        }

        var badmintonCourts = new List<BadmintonCourt>()
        {
            new BadmintonCourt()
            {
                //Id = 1;
                CourtName = "Vu Tru",
                HourStart = 5,
                MinuteStart = 0,
                HourEnd = 23,
                MinuteEnd = 0,
                Address = "992 Đ. Nguyễn Duy Trinh, Phường Phú Hữu, Thủ Đức, Thành phố Hồ Chí Minh",
                PriceAtWeekend = 110000,
                PricePerHour = 100000,
                ProfileImage = "",
                AccountId = 1,
                NumberOfCourt = 9
            },
            new BadmintonCourt()
            {
                CourtName = "Long Sen",
                HourStart = 4,
                MinuteStart = 30,
                HourEnd = 24,
                MinuteEnd = 0,
                Address = "39p đường gò cát phường Phú hữu Quận 9 TPTĐ, Thành phố Hồ Chí Minh",
                PriceAtWeekend = 100000,
                PricePerHour = 80000,
                ProfileImage = "",
                AccountId = 2,
                NumberOfCourt = 9
            },
            new BadmintonCourt()
            {
                //Id = 1;
                CourtName = "Khánh Linh",
                HourStart = 4,
                MinuteStart = 30,
                HourEnd = 24,
                MinuteEnd = 0,
                Address = "15 Đ. số 28, Cát Lái, Quận 2, Thành phố Hồ Chí Minh",
                PriceAtWeekend = 120000,
                PricePerHour = 110000,
                ProfileImage = "", 
                AccountId = 3,
                NumberOfCourt = 9
            },
            new BadmintonCourt()
            {
                //Id = 1;
                CourtName = "Quoc Tung",
                HourStart = 5,
                MinuteStart = 0,
                HourEnd = 22,
                MinuteEnd = 0,
                Address = "408/8 Nguyễn Xiển, Long Thạnh Mỹ, Quận 9, Thành phố Hồ Chí Minh",
                PriceAtWeekend = 80000,
                PricePerHour = 70000,
                ProfileImage = "",
                AccountId = 4,
                NumberOfCourt = 9
            },
            new BadmintonCourt()
            {
                //Id = 1;
                CourtName = "Mega Sea",
                HourStart = 4,
                MinuteStart = 0,
                HourEnd = 22,
                MinuteEnd = 0,
                Address = "545 Nguyễn Xiển, Long Thạnh Mỹ, Quận 9, Thành phố Hồ Chí Minh",
                PriceAtWeekend = 100000,
                PricePerHour = 90000,
                ProfileImage = "",
                AccountId = 5,
                NumberOfCourt = 9
            }
        };
        foreach (var item in badmintonCourts)
        {
            await _badmintonCourtService.AddBadmintonCourt(item);
        }
    }

    public async Task SeedRole()
    {
        if (await _context.Roles.AnyAsync())
        {
            return;
        }

        var roles = new List<Role>()
        {
            new Role()
            {
                RoleName = "Player"
            },
            new Role()
            {
                RoleName = "Owner"
            },
            new Role()
            {
                RoleName = "Admin"
            }
        };
        foreach (var item in roles)
        {
            await _roleService.AddRole(item);
        }
    }

    public async Task SeedAccount()
    {
        if (await _context.Accounts.AnyAsync())
        {
            return;
        }
        var accounts = new List<Account>()
        {
            new Account()
            {
                Email = "nguyenho30112003@gmail.com",
                Password = "12345",
                FullName = "Hồ Dương Trung Nguyên",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Bank = "",
                CardNumber = "",
                RoleId = 2
            },
            new Account()
            {
                Email = "minhta@gmail.com",
                Password = "12345",
                FullName = "Trần Ánh Minh",
                PhoneNumber = "0123456789",
                DateOfBirth = DateTime.Now,
                Bank = "",
                CardNumber = "",
                RoleId = 2
            },
            new Account()
            {
                Email = "phamvinhson@gmail.com",
                Password = "12345",
                FullName = "Phạm Vĩnh Sơn",
                PhoneNumber = "0918213432",
                DateOfBirth = DateTime.Now,
                Bank = "",
                CardNumber = "",
                RoleId = 2
            },
            new Account()
            {
                Email = "phucanhdodang@gmail.com",
                Password = "12345",
                FullName = "Đỗ Đặng Phúc Anh",
                PhoneNumber = "0913283481",
                DateOfBirth = DateTime.Now,
                Bank = "",
                CardNumber = "",
                RoleId = 2
            },
            new Account()
            {
                Email = "nguyetanhtran@gmail.com",
                Password = "12345",
                FullName = "Tran Nguyet Anh",
                PhoneNumber = "0874234128",
                DateOfBirth = DateTime.Now,
                Bank = "",
                CardNumber = "",
                RoleId = 3
            },
            new Account()
            {
                Email = "nguyenngocnghi@gmail.com",
                Password = "12345",
                FullName = "Nguyen Ngoc Nghi",
                PhoneNumber = "0857281943",
                DateOfBirth = DateTime.Now,
                Bank = "",
                CardNumber = "",
                RoleId = 1
            },
            new Account()
            {
                Email = "hoanglamnguyen@gmail.com",
                Password = "12345",
                FullName = "Nguyen Hoang Lam",
                PhoneNumber = "0542312945",
                DateOfBirth = DateTime.Now,
                Bank = "",
                CardNumber = "",
                RoleId = 2
            }
        };
        foreach (var item in accounts)
        {
            await _accountService.AddNewAccount(item);
        }
    }
}