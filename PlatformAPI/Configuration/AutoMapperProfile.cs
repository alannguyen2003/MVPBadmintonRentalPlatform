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
        BadmintonCourtEntityMap();
        BadmintonCourtServiceEntityMap();
        SlotBadmintonCourtEntityMap();
    }

    private void AuthenticationEntityMap()
    {
        CreateMap<Account, AccountResponse>()
            .ReverseMap();
        CreateMap<LoginRequest, Account>()
            .ReverseMap();
        CreateMap<PlayerRegisterRequest, Account>()
            .ReverseMap();
        CreateMap<OwnerRegisterRequest, Account>()
            .ReverseMap();
        CreateMap<EditAccountRequest, Account>()
            .ReverseMap();
    }

    private void BadmintonCourtEntityMap()
    {
        CreateMap<OwnerRegisterRequest, BadmintonCourt>()
            .ReverseMap();
        CreateMap<ServiceCourt, ServiceOfCourtResponse>()
            .ReverseMap();
        CreateMap<BadmintonCourtRequest, BadmintonCourt>()
            .ReverseMap();
        CreateMap<BadmintonCourt, BadmintonCourtResponse>()
            .ReverseMap();
    }

    private void BadmintonCourtServiceEntityMap()
    {
        CreateMap<ServiceCourtRequest, ServiceCourt>()
            .ReverseMap();
    }

    private void SlotBadmintonCourtEntityMap()
    {
        CreateMap<Slot, SlotResponse>()
            .ReverseMap();
    }
    
    
    
}