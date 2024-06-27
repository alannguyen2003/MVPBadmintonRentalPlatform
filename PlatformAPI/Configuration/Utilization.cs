using BusinessObject;
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
        _slotService = slotService;
    }
    public async Task<List<GenerateSlotResponse>> GenerateSlotResponseForBadmintonCourt(int badmintonCourtId, DateTime date)
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
            var slots = await _slotService.GetSlotByDate(date);
            if (!slots.Any()) slots = new List<Slot>();
            for (int j = 0; j < hours.Count - 1; j++)
            {
                var minuteStart = minutes[j] == 0 ? "00" : "" + minutes[j];
                var minuteEnd = minutes[j+1] == 0 ? "00" : "" + minutes[j+1];
                string timeFrame = hours[j] + ":" + minuteStart + " - " +
                                   hours[j + 1] + ":" + minuteEnd;
                bool isBooked = false;
                for (int k = 0; k < slots.Count; k++)
                {
                    if (timeFrame.Equals(slots[k].TimeFrame) && slots[k].CourtId == courts[i].Id)
                    {
                        isBooked = true;
                        break;
                    }
                }

                if (isBooked)
                {
                    slot.SlotWithStatusResponses.Add(new SlotWithStatusResponse()
                    {
                        TimeFrame = timeFrame,
                        IsBooked = true
                    });
                }
                else
                {
                    slot.SlotWithStatusResponses.Add(new SlotWithStatusResponse()
                    {
                        TimeFrame = timeFrame,
                        IsBooked = false
                    });
                }
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
        var slotsBooked = await _slotService.GetSlotByDate(date);
        for (int i = 0; i < hours.Count - 1; i++)
        {
            var minuteStart = minutes[i] == 0 ? "00" : "" + minutes[i];
            var minuteEnd = minutes[i+1] == 0 ? "00" : "" + minutes[i+1];
            string timeFrame = hours[i] + ":" + minuteStart + " - " +
                               hours[i + 1] + ":" + minuteEnd;
            bool isBooked = false;
            for (int j = 0; j < slotsBooked.Count; j++)
            {
                if (slotsBooked[j].TimeFrame.Equals(timeFrame) && slotsBooked[j].CourtId == court.Id) 
                {
                    isBooked = true;
                    break;
                }
            }
            if (isBooked)
            {
                slot.SlotWithStatusResponses.Add(new SlotWithStatusResponse()
                {
                    TimeFrame = timeFrame,
                    IsBooked = true
                });
            }
            else
            {
                slot.SlotWithStatusResponses.Add(new SlotWithStatusResponse()
                {
                    TimeFrame = timeFrame,
                    IsBooked = false
                });
            }
        }
        return slot;
    }
}