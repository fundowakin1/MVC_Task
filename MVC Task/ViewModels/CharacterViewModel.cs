using System.Collections.Generic;
using System.ComponentModel;
using MVC_Task.Models;

namespace MVC_Task.ViewModels
{
    public class CharacterViewModel
    {
        public static string Name { get; set; }
        public static string Race { get; set; }
        public static int AmountOfTurns { get; set; }
        public static bool HasWon { get; set; } 
        public static decimal AmountOfMoney { get; set; }
        public static decimal AmountOfMoneyToInteract { get; set; }
        public static bool IsAlive { get; set; }
        public static int NumberOfRetries { get; set; }
        public static int MetThieves { get; set; }
        public static int PintsOfBeer { get; set; }
        public static string SpecialNpcMet { get; set; }
        public static string NpcMet { get; set; }
    }
}