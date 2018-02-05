using System.Web.Helpers;
using SudisIm.Model.Models;

namespace SudisIm.Models.Calendar
{
    public class CalendarEventDto
    {
        public string id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string location { get; set; }
        public bool allDay { get; set; }
        public string backgroundColor { get; set; }
        public bool isGame { get; set; }
        public static implicit operator CalendarEventDto(Game game)
        {
            return new CalendarEventDto()
            {
                id = game.Id.ToString(),
                start = game.StartTime.ToString("o"),
                end = game.StartTime.AddHours(3).ToString("o"),
                title = game.GetGameTitle(),
                location = game.GetLocation(),
                isGame =  true
            };
        }
        public static implicit operator CalendarEventDto(Absence absence)
        {
            return new CalendarEventDto()
            {
                id = absence.Id.ToString(),
                start = absence.StartDate.ToString("o"),
                end = absence.EndDate.ToString("o"),
                allDay = true,
                title = absence.Excuse,
                backgroundColor = "#ff0000"
            };
        }
    }
}