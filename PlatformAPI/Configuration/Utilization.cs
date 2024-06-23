using DataAccess;
using DataTransfer.Response;
using Repository.Interface;
using Service.Interface;

namespace PlatformAPI.Configuration;

public class Utilization
{
    private readonly IBadmintonCourtService _badmintonCourtService;
    private readonly ICourtService _courtService;
    private readonly ISlotService _slotService;

    public Utilization(IBadmintonCourtService badmintonCourtService, ICourtService courtService,
        ISlotService slotService)
    {
        _badmintonCourtService = badmintonCourtService;
        _courtService = courtService;
    }
    public async Task<List<GenerateSlotResponse>> GenerateSlotResponseForBadmintonCourt(int badmintonCourtId)
    {
        var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(badmintonCourtId);
        var courts = await _courtService.GetAllCourtsWithBadmintonCourt(badmintonCourtId);
        var listSlot = new List<GenerateSlotResponse>();
        for (int i = 0; i < courts.Count; i++)
        {
            var slot = new GenerateSlotResponse()
            {
                Id = courts[i].Id,
                CourtCode = courts[i].CourtCode,
                SlotWithStatusResponses = new List<SlotWithStatusResponse>()
            };
            List<int> hours = new List<int>();
            List<int> minutes = new List<int>();
            SlotDAO.Instance.GenerateTimeSlots(new TimeSpan(badmintonCourt.HourStart, badmintonCourt.MinuteStart, 0),
                new TimeSpan(badmintonCourt.HourEnd, badmintonCourt.MinuteEnd, 0),
                new TimeSpan(0, 30, 0),
                out hours, out minutes);
            for (int j = 0; j < hours.Count - 1; j++)
            {
                var minuteStart = minutes[j] == 0 ? "00" : "" + minutes[j];
                var minuteEnd = minutes[j+1] == 0 ? "00" : "" + minutes[j+1];
                slot.SlotWithStatusResponses.Add(new SlotWithStatusResponse()
                {
                    TimeFrame = hours[j] + ":" + minuteStart + " - " +
                                hours[j+1] + ":" + minuteEnd,
                    IsBooked = false
                });
            }
            listSlot.Add(slot);
        }
        return listSlot;
    }

    public async Task<GenerateSlotResponse> GenerateSlotForBadmintonCourtWithCourt(int badmintonCourtId, int courtId, DateTime date)
    {
        var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(badmintonCourtId);
        var court = await _courtService.GetCourt(courtId);  
        var slots = await _slotService.GetSlotByDate(date);
        var slot = new GenerateSlotResponse()
        {
            Id = court!.Id,
            CourtCode = court.CourtCode,
            SlotWithStatusResponses = new List<SlotWithStatusResponse>()
        };
        List<int> hours = new List<int>();
        List<int> minutes = new List<int>();
        SlotDAO.Instance.GenerateTimeSlots(new TimeSpan(badmintonCourt.HourStart, badmintonCourt.MinuteStart, 0),
            new TimeSpan(badmintonCourt.HourEnd, badmintonCourt.MinuteEnd, 0),
            new TimeSpan(0, 30, 0),
            out hours, out minutes);
        for (int i = 0; i < hours.Count - 1; i++)
        {
            var minuteStart = minutes[i] == 0 ? "00" : "" + minutes[i];
            var minuteEnd = minutes[i+1] == 0 ? "00" : "" + minutes[i+1];
            var timeFrame = hours[i] + ":" + minuteStart + " - " +
                            hours[i + 1] + ":" + minuteEnd;
            
            slot.SlotWithStatusResponses.Add(new SlotWithStatusResponse()
            {
                TimeFrame = timeFrame,
                IsBooked = false
            });
        }
        
        return slot;
    }
}