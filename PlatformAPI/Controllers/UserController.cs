using System.Security.Claims;
using AutoMapper;
using BusinessObject;
using DataTransfer;
using DataTransfer.Request;
using DataTransfer.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Service.Interface;

namespace PlatformAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IBookingService _bookingService;
    private readonly IBadmintonCourtService _badmintonCourtService;
    private readonly IMapper _mapper;

    public UserController(IAccountService accountService, IMapper mapper, IBookingService bookingService,
        IBadmintonCourtService badmintonCourtService)
    {
        _accountService = accountService;
        _mapper = mapper;
        _bookingService = bookingService;
        _badmintonCourtService = badmintonCourtService;
    }

    [HttpGet("get-profile")]
    [Authorize]
    public async Task<IActionResult> GetProfile()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var userId = identity.FindFirst("UserId").Value;
        var account = await _accountService.GetAccount(Int32.Parse(userId));
        return Ok(new ApiResponse()
        {
            StatusCode = 200, Message = "Get account successful!",
            Data = _mapper.Map<AccountResponse>(account)
        });
    }
    
    [HttpGet("get-detail-user")]
    [Authorize]
    public async Task<IActionResult> GetDetailUser(int userId)
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        var account = await _accountService.GetAccount(userId);
        return Ok(new ApiResponse()
        {
            StatusCode = 200, Message = "Get account successful!",
            Data = _mapper.Map<AccountResponse>(account)
        });
    }

    [HttpPost("edit-user-profile")]
    public async Task<IActionResult> EditUserProfileAsync(EditAccountRequest request)
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var account = _mapper.Map<Account>(request);
            var userId = identity.FindFirst("UserId").Value;
            account.Id = Int32.Parse(userId);
            await _accountService.EditProfileAsync(account);
            return Ok(new ApiResponse()
            {
                StatusCode = 200, 
                Message = "Edit user profile successful!",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Edit profile failed, see log: " + ex.Message,
                Data = null
            });
        }
    }

    [HttpGet("get-number-of-player-and-owner")]
    public async Task<IActionResult> GetNumberOfPlayerAndOwner()
    {
        return Ok(new ApiResponse()
        {
            StatusCode = 200,
            Message = "Get number of player and owner successful!",
            Data = new NumberOfPlayerAndOwner()
            {
                NumberOfOwner = await _accountService.GetNumberOfOwner(),
                NumberOfPlayer = await _accountService.GetNumberOfPlayer()
            }
        });
    }

    [HttpGet("load-balance")]
    [Authorize]
    public async Task<IActionResult> LoadBalanceForCourtOwner()
    {
        try
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = Int32.Parse(identity.FindFirst("UserId").Value);
            var user = await _accountService.GetAccount(userId);
            var badmintonCourt = await _badmintonCourtService.GetBadmintonCourtWithOwnerId(userId);
            var bookings = await _bookingService.GetAllBookingsOfBadmintonCourtBeforeNow(badmintonCourt.Id);
            int balance = 0;
            foreach (var item in bookings)
            {
                if (item.BookingStatusId == 2)
                {
                    balance += (int)(item.Price * 0.15);
                    await _bookingService.UpdateBookingForCourtOwner(item);
                }
            }

            user.Balance += balance;
            await _accountService.EditProfileAsync(user);
            return Ok(new ApiResponse()
            {
                StatusCode = 200, 
                Message = "Load balance successful!"
            });
        }
        catch (Exception ex)
        {
            return Ok(new ApiResponse()
            {
                StatusCode = 400,
                Message = "Error in load balance: " + ex.Message
            });
        }
        
    }

    [HttpGet("seed-user")]
    public async Task<IActionResult> SeedingUser()
    {
        var user = new List<Account>()
        {
            new Account()
            {
                Email = "quocantruong@gmail.com",
                Password = "12345",
                FullName = "Trương Trần Quốc An",
                PhoneNumber = "077618239",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "anhthu@gmail.com",
                Password = "12345",
                FullName = "Trần Anh Thư",
                PhoneNumber = "07761823992",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "vinhson@gmail.com",
                Password = "12345",
                FullName = "Phạm Vĩnh Sơn",
                PhoneNumber = "0888238792",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "toantran@gmail.com",
                Password = "12345",
                FullName = "Trần Đức Toàn",
                PhoneNumber = "0812839232",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "trunghai@gmail.com",
                Password = "12345",
                FullName = "Võ Nguyễn Trung Hải",
                PhoneNumber = "0919239723",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "khangkien@gmail.com",
                Password = "12345",
                FullName = "Lưu Khang Kiện",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "phihong@gmail.com",
                Password = "12345",
                FullName = "Hoàng Phi Hồng",
                PhoneNumber = "08928382838",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "nhuthuan@gmail.com",
                Password = "12345",
                FullName = "Vũ Thị Như Thuần",
                PhoneNumber = "0843239292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "tiendattran@gmail.com",
                Password = "12345",
                FullName = "Trần Tiến Đạt",
                PhoneNumber = "1231898823",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "quyentranbadminton@gmail.com",
                Password = "12345",
                FullName = "Trần Minh Quyền",
                PhoneNumber = "092938283",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "phuongtrinh@gmail.com",
                Password = "12345",
                FullName = "Nguyễn Thị Phương Trinh",
                PhoneNumber = "0882399782",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "thanhtam@gmail.com",
                Password = "12345",
                FullName = "Lý Thanh Tâm",
                PhoneNumber = "0823789232",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "huumanh@gmail.com",
                Password = "12345",
                FullName = "Nguyễn Trần Hữu Mạnh",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "tamluu@gmail.com",
                Password = "12345",
                FullName = "Lưu Mỹ Tâm",
                PhoneNumber = "09818237823",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "minhtuan@gmail.com",
                Password = "12345",
                FullName = "Trần Minh Tuấn",
                PhoneNumber = "01273908822",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "tuem@gmail.com",
                Password = "12345",
                FullName = "Lý Thanh Tú Em",
                PhoneNumber = "0918882322",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "phanphat123@gmail.com",
                Password = "12345",
                FullName = "Phan Cả Phát",
                PhoneNumber = "0889823203",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "baominh@gmail.com",
                Password = "12345",
                FullName = "Bùi Vũ Bảo Minh",
                PhoneNumber = "0888237892",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "thanbaominh@gmail.com",
                Password = "12345",
                FullName = "Thân Hàn Bảo Minh",
                PhoneNumber = "0988382384",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "phannam@gmail.com",
                Password = "12345",
                FullName = "Phan Hải Nam",
                PhoneNumber = "08812378923",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "phanson@gmail.com",
                Password = "12345",
                FullName = "Phan Hữu Hoàng Sơn",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "myduyen@gmail.com",
                Password = "12345",
                FullName = "Lê Thị Mỹ Duyên",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "thuphuong@gmail.com",
                Password = "12345",
                FullName = "Đỗ Thị Thu Phương",
                PhoneNumber = "09929389234",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "thuytrang@gmail.com",
                Password = "12345",
                FullName = "Lê Thị Thùy Trang",
                PhoneNumber = "0882389982",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "huyhungleviettel@gmail.com",
                Password = "12345",
                FullName = "Lê Huy Hùng",
                PhoneNumber = "0878293923",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "phuocthinh@gmail.com",
                Password = "12345",
                FullName = "Trần Phước Thịnh",
                PhoneNumber = "0818239823",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "huyhoang@gmail.com",
                Password = "12345",
                FullName = "Lê Huy Hoàng",
                PhoneNumber = "08892323882",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "conghoang@gmail.com",
                Password = "12345",
                FullName = "Nguyễn Công Hoàng",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "minhquan@gmail.com",
                Password = "12345",
                FullName = "Lê Minh Quân",
                PhoneNumber = "090203992",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "minhlethi@gmail.com",
                Password = "12345",
                FullName = "Lê Thị Minh",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "liennguyen@gmail.com",
                Password = "12345",
                FullName = "Nguyễn Thị Liên",
                PhoneNumber = "092932398",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "tranminhanh@gmail.com",
                Password = "12345",
                FullName = "Trần Minh Anh",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "minhthu@gmail.com",
                Password = "12345",
                FullName = "Lê Thị Minh Thư",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "anhthuhoang@gmail.com",
                Password = "12345",
                FullName = "Hoàng Từ Anh Thư",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "nhuquynh@gmail.com",
                Password = "12345",
                FullName = "Vũ Thị Như Quỳnh",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "nhatduc@gmail.com",
                Password = "12345",
                FullName = "Nguyễn Nhật Đức",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "trungkien@gmail.com",
                Password = "12345",
                FullName = "Nguyễn Thái Trung Kiên",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "vancao@gmail.com",
                Password = "12345",
                FullName = "Đặng Văn Cao",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            
            new Account()
            {
                Email = "nhuy12345@gmail.com",
                Password = "12345",
                FullName = "Đặng Trần Như Ý",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "phuoctran@gmail.com",
                Password = "12345",
                FullName = "Trần Công Phước",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "huuloc@gmail.com",
                Password = "12345",
                FullName = "Trần Hữu Lộc",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "datnguyen@gmail.com",
                Password = "12345",
                FullName = "Nguyễn Hán Đạt",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "toannguyen@gmail.com",
                Password = "12345",
                FullName = "Nguyễn Văn Toàn",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "ngocphuc@gmail.com",
                Password = "12345",
                FullName = "Dương Ngọc Phúc",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
            new Account()
            {
                Email = "khaminh@gmail.com",
                Password = "12345",
                FullName = "Lý Khả Minh",
                PhoneNumber = "0847919292",
                DateOfBirth = DateTime.Now,
                Gender = "",
                Bank = "",
                CardNumber = "",
                Balance = 0,
                RoleId = 1
            },
        };
        await _accountService.AddRangeAccountAsync(user);
        return Ok();
    }
}