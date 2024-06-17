using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class ServiceCourtService : IServiceCourtService
{
    private readonly IServiceCourtRepository _serviceCourtRepository;

    public ServiceCourtService(IServiceCourtRepository serviceCourtRepository)
    {
        _serviceCourtRepository = serviceCourtRepository;
    }
    
    public async Task<List<ServiceCourt>> GetAllServices()
    {
        return await _serviceCourtRepository.GetAllServices();
    }

    public async Task<List<ServiceCourt>> GetAllSerivcesBasedOnBadmintonCourt(int badmintonCourtId)
    {
        return await _serviceCourtRepository.GetAllServicesBasedOnBadmintonCourt(badmintonCourtId);
    }

    public async Task AddServiceCourt(ServiceCourt serviceCourt)
    {
        await _serviceCourtRepository.AddService(serviceCourt);
    }

    public async Task AddRangeServiceCourt(List<ServiceCourt> listService)
    {
        await _serviceCourtRepository.AddRangeService(listService);
    }

    public void GenerateTimeSlot(TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration, out List<int> hours, out List<int> minutes)
    {   
        hours = new List<int>();
        minutes = new List<int>();
        if (startTime > endTime)
        {
            throw new ArgumentException("Start time cannot be after end time.");
        }

        var totalSeconds = (endTime - startTime).TotalSeconds;
        var numSlots = (int)Math.Ceiling(totalSeconds / slotDuration.TotalSeconds) + 1;

        var slots = new List<TimeSpan>();
        for (int i = 0; i < numSlots; i++)
        {
            var currentSlotStartTime = startTime.Add(TimeSpan.FromSeconds(i * slotDuration.TotalSeconds));
            var currentSlotEndTime = currentSlotStartTime.Add(slotDuration);
            slots.Add(new TimeSpan(currentSlotStartTime.Hours, currentSlotStartTime.Minutes, 0));
            hours.Add(currentSlotStartTime.Hours);
            minutes.Add(currentSlotStartTime.Minutes);
        }
    }

    public async Task<List<TimeSpan>> GenerateTimeSlot(TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration)
    {
        if (startTime > endTime)
        {
            throw new ArgumentException("Start time cannot be after end time.");
        }

        var totalSeconds = (endTime - startTime).TotalSeconds;
        var numSlots = (int)Math.Ceiling(totalSeconds / slotDuration.TotalSeconds) + 1;

        var slots = new List<TimeSpan>();
        for (int i = 0; i < numSlots; i++)
        {
            var currentSlotStartTime = startTime.Add(TimeSpan.FromSeconds(i * slotDuration.TotalSeconds));
            var currentSlotEndTime = currentSlotStartTime.Add(slotDuration);
            slots.Add(new TimeSpan(currentSlotStartTime.Hours, currentSlotStartTime.Minutes, 0));
        }
        return slots;
    }
}