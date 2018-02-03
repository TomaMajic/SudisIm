namespace SudisIm.Model.Models
{
    public class Notification
    {
        public Notification()
        {}

        public Notification(Game game, Referee referee)
        {
            this.Game = game;
            this.Referee = referee;
        }

        private Game _game;
        public virtual long Id { get; set; }
        public virtual bool IsOpened { get; set; }
        public virtual Referee Referee { get; set; }

        public virtual Game Game
        {
            get { return _game; }
            set
            {
                _game = value;
                this.Text =
                    $"Dodijeljeni ste utakmici u {_game.City?.Name} - {_game.Address} u {_game.GetFormatedStartTime()}";
            }
        }

        public virtual string Text { get; set; }
    }
}
