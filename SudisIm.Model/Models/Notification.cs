namespace SudisIm.Model.Models
{
    public class Notification
    {
        public virtual long Id { get; set; }
        public virtual bool IsOpened { get; set; }
        public virtual Referee Referee { get; set; }
        public virtual Game Game { get; set; }
        public virtual string Text { get; set; }
    }
}
