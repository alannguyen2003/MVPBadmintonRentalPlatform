using DataAccess;
using DataTransfer.Response;
using Repository.Interface;
using Service.Interface;

namespace PlatformAPI.Configuration;

public class Utilization
{
    private readonly IBadmintonCourtService _badmintonCourtService;
    private readonly ICourtService _courtService;

    public Utilization(IBadmintonCourtService badmintonCourtService, ICourtService courtService)
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
                TimeFrame = new List<string>()
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
                slot.TimeFrame.Add( hours[j] + ":" + minuteStart + " - " +
                                    hours[j+1] + ":" + minuteEnd);
            }
            listSlot.Add(slot);
        }
        return listSlot;
    }

    public async Task<GenerateSlotResponse> GenerateSlotForBadmintonCourtWithCourt(int badmintonCourtId, int courtId)
    {
        var badmintonCourt = await _badmintonCourtService.GetBadmintonCourt(badmintonCourtId);
        var court = await _courtService.GetCourt(courtId);  
        var slot = new GenerateSlotResponse()
        {
            Id = court!.Id,
            CourtCode = court.CourtCode,
            TimeFrame = new List<string>()
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
            slot.TimeFrame.Add( hours[i] + ":" + minuteStart + " - " +
                                hours[i+1] + ":" + minuteEnd);
        }

        return slot;
    }
}