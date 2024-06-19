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
    private readonly ICourtService _courtService;
    private readonly ISlotService _slotService;
    private readonly IBankService _bankService;
    private readonly IPaymentMethodService _paymentMethodService;
    private readonly AppDbContext _context;

    public Seeding(IAccountService accountService, IRoleService roleService,
        IBadmintonCourtService badmintonCourtService, IServiceCourtService serviceCourtService,
        ICourtService courtService, ISlotService slotService, IBankService bankService,
        IPaymentMethodService paymentMethodService)
    {
        _accountService = accountService;
        _context = new AppDbContext();
        _roleService = roleService;
        _badmintonCourtService = badmintonCourtService;
        _serviceCourtService = serviceCourtService;
        _courtService = courtService;
        _slotService = slotService;
        _bankService = bankService;
        _paymentMethodService = paymentMethodService;
    }

    public async Task MigrateDatabaseAsync()
    {
        await _context.Database.MigrateAsync();
    }

    public async Task SeedPaymentMethod()
    {
        if (await _context.PaymentMethods.AnyAsync())
        {
            return;
        }

        var payments = new List<PaymentMethod>()
        {
            new PaymentMethod()
            {
                PaymentName = "Cash On Delivery",
                BankId = 1
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 2
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 3
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 4
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 5
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 6
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 7
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 8
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 9
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 10
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 11
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 12
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 13
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 14
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 15
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 16
            },
            new PaymentMethod()
            {
                PaymentName = "Banking",
                BankId = 17
            }
        };
        await _paymentMethodService.AddRangePaymentMethodAsync(payments);
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
        await _serviceCourtService.AddRangeServiceCourt(serviceCourts);
    }

    public async Task SeedBanks()
    {
        if (await _context.Banks.AnyAsync())
        {
            return;
        }

        List<Bank> banks = new List<Bank>()
        {
            new Bank()
            {
                BankCode = "ABBank",
                BankName = "NH TMCP An Bình",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "ACB",
                BankName = "NH TMCP Á Châu",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Agribank",
                BankName = "NH Nông Nghiệp Và Phát Triển Nông Thôn VN",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Bac A Bank",
                BankName = "NH TMCP Bac A",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "BaoViet Bank",
                BankName = "NH TMCP Bảo Việt",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "BIDV",
                BankName = "NH TMCP Đầu Tư Và Phát Triển VN",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "BVBank",
                BankName = "NH TMCP Bản Việt",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "CAKE",
                BankName = "NH Số CAKE by VPBank",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "CBBank",
                BankName = "NH TM TNHH MTV Xây Dựng Việt Nam",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "CIMB",
                BankName = "NH TNHH MTV CIMB Viet Nam",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Co-opBank",
                BankName = "NH Hợp Tác",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "DBS - HCM",
                BankName = "NH DBS - Chi nhanh TPHCM",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "DongABank",
                BankName = "NH TMCP Dong A",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Eximbank",
                BankName = "NH TMCP Xuất Nhập Khẩu VN",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "GPBank",
                BankName = "NH TM TNHH MTV Dau Khi Toan Cau",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "HDBank",
                BankName = "NH TMCP Phat Trien TPHCM",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Hong Leong Bank",
                BankName = "NH TNHH MTV Hongleong VN",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "HSBC",
                BankName = "NH TNHH MTV HSBC Viet Nam",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Indovina Bank",
                BankName = "NH TNHH Indovina",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Industrial Bank Of Korea",
                BankName = "NH Cong Nghiep Han Quoc CN Ha Noi",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "KB HCM",
                BankName = "NH Kookmin - Chi nhanh TPHCM",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "KB HN",
                BankName = "NH Kookmin - Chi nhanh Ha Noi",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "KBank",
                BankName = "NH Dai Chung TNHH Kasikornbank - Chi nhanh TPHCM",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Kien Long Bank",
                BankName = "NH TMCP Kien Long",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "LPBank",
                BankName = "NH TMCP Buu Dien Lien Viet",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "MBBank",
                BankName = "NH TMCP Quan Doi",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "MSB",
                BankName = "NH TMCP Hang Hai VN",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Nam A Bank",
                BankName = "NH TMCP Nam A",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "NCB",
                BankName = "NH TMCP Quoc Dan",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Nonghyup Bank - HN",
                BankName = "NH Nonghyup - Chi nhanh HN",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "OCB",
                BankName = "NH TMCP Phuong Dong",
                ImageUrl = "",
                Description = ""
            },
            new Bank()
            {
                BankCode = "Oceanbank",
                BankName = "NH TM TNHH MTV Dai Duong",
                ImageUrl = "",
                Description = ""
            }
        };
        await _bankService.AddRangeBanks(banks);
    }

    public async Task SeedSlots()
    {
        if (await _context.Slots.AnyAsync())
        {
            return;
        }
        var slots = new List<Slot>();
        var badmintonCourts = await _context.BadmintonCourts.ToListAsync();
        foreach (var badmintonCourt in badmintonCourts)
        {
            var courts = await _context.Courts
                .Where(court => court.BadmintonCourtId == badmintonCourt.Id)
                .ToListAsync();
            foreach (var court in courts)
            {
                await _slotService.AddRangeSlotsForBadmintonCourt(badmintonCourt.HourStart,
                    badmintonCourt.MinuteStart, badmintonCourt.HourEnd, badmintonCourt.MinuteEnd, court.Id);
            }
        }
    }

    public async Task SeedCourts()
    {
        if (await _context.Courts.AnyAsync())
        {
            return;
        }

        var badmintonCourts = await _context.BadmintonCourts.ToListAsync();
        foreach (var badmintonCourt in badmintonCourts)
        {
            var courts = new List<Court>();
            for (int i = 1; i <= badmintonCourt.NumberOfCourt; i++)
            {
                courts.Add(new Court()
                {
                    CourtCode = i.ToString(),
                    BadmintonCourtId = badmintonCourt.Id
                });
            }
            await _courtService.AddRangeCourts(courts);
        }
    }

    public async Task SeedSlotForBadmintonCourts()
    {
        if (await _context.Slots.AnyAsync())
        {
            return;
        }

        var courts = await _context.Courts
            .Include(badmintonCourt => badmintonCourt.BadmintonCourt)
            .ToListAsync();
        foreach (var court in courts)
        {
            var hourStart = court.BadmintonCourt.HourStart;
            var minuteStart = court.BadmintonCourt.MinuteStart;
            var hourEnd = court.BadmintonCourt.HourEnd;
            var minuteEnd = court.BadmintonCourt.MinuteEnd;
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
                PriceAtHoliday = 90000,
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
                PriceAtHoliday = 90000,
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
                PriceAtHoliday = 90000,
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
                PriceAtHoliday = 90000,
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
                PriceAtHoliday = 90000,
                ProfileImage = "",
                AccountId = 5,
                NumberOfCourt = 9
            }
        };
        await _badmintonCourtService.AddRangeBadmintonCourt(badmintonCourts);
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
        await _roleService.AddRangeRoleAsync(roles);
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
        await _accountService.AddRangeAccountAsync(accounts);
    }
}