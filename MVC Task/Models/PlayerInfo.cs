namespace MVC_Task.Models
{
    public class PlayerInfo
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public decimal AmountOfMoney { get; set; }

        public virtual Player Player { get; set; }

    }
}
