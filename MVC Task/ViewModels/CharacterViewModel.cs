using System.Collections.Generic;
using MVC_Task.Models;

namespace MVC_Task.ViewModels
{
    public class CharacterViewModel
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public int AmountOfTurns { get; set; } = 0;
        public bool HasWon { get; set; } = false;
        public decimal AmountOfMoney { get; set; } = 100m;
        public bool IsAlive { get; set; }
    }
}