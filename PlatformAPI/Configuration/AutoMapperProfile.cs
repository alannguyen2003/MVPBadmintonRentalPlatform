using AutoMapper;
using BusinessObject;
using DataTransfer.Request;
using DataTransfer.Response;

namespace PlatformAPI.Configuration;

public class AutoMapperProfile : Profile
{

    public AutoMapperProfile()
    {
        AuthenticationEntityMap();
    }

    private void AuthenticationEntityMap()
    {
        CreateMap<Account, AccountResponse>()
            .ReverseMap();
        CreateMap<LoginRequest, Account>()
            .ReverseMap();
        CreateMap<PlayerRegisterRequest, Account>()
            .ReverseMap();
    }
    
}