using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class SlotDAO
{
    private readonly AppDbContext _context;
    private static SlotDAO instance;
    
    public SlotDAO()
    {
        _context = new AppDbContext();
    }

    public static SlotDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SlotDAO();
            }
            return instance;
        }
    }

    public async Task<List<Slot>> GetAllSlots()
    {
        return await _context.Slots.ToListAsync();
    }

    public async Task<List<Slot>> GetAllSlotsOfCourt(int courtId)
    {
        return await _context.Slots
            .Where(slot => slot.CourtId == courtId)
            .ToListAsync();
    }

    public async Task<List<Slot>> GetAllSlotsOfBadmintonCourt(int badmintonCourtId)
    {
        List<Slot> listSlot = new();
        var listCourt = await _context.Courts
            .Where(badmintonCourt => badmintonCourt.BadmintonCourtId == badmintonCourtId)
            .ToListAsync();
        foreach (var item in listCourt)
        {
            listSlot.AddRange(await _context.Slots
                .Where(slot => slot.CourtId == item.Id)
                .ToListAsync());
        }
        return listSlot;
    }

    public async Task AddRangeSlotForBadmintonCourt(TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration, int courtId)
    {
        List<int> hours = new List<int>();
        List<int> minutes = new List<int>();
        GenerateTimeSlots(startTime, endTime, slotDuration, out hours, out minutes);
        for (int i = 0; i < hours.Count-1; i++)
        {
            await _context.Slots.AddAsync(new Slot()
            {
                HourStart = hours[i],
                MinuteStart = minutes[i],
                HourEnd = hours[i + 1],
                MinuteEnd = minutes[i + 1],
                CourtId = courtId
            });
        }
        await _context.SaveChangesAsync();
    }

    public void GenerateTimeSlots(TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration, out List<int> hours,
        out List<int> minutes)
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
}