namespace SudisIm.Model.Models
{
    public class Notification
    {
        public long Id { get; set; }
        public bool IsOpened { get; set; }
        public long RefereeId { get; set; }
        public long GameId { get; set; }
        public string Text { get; set; }
    }
}
