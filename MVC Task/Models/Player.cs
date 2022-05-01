namespace MVC_Task.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int AmountOfTurns { get; set; }
        public bool IsAlive { get; set; }
        public bool HasWon { get; set; }
        public virtual PlayerInfo PlayerInfoEntity { get; set; }
    }
}