using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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

        public static string FormatMoney()
        {
            var parts = AmountOfMoney.ToString("0.00", CultureInfo.InvariantCulture).Split('.').Select(int.Parse).ToArray();
            if (parts[0] != 0 && parts[1] != 0)
                return $"Your balance: {parts[0]} AM$ and {parts[1]} pennies.";
            if (parts[0] == 0 && parts[1] != 0)
                return $"Your balance: {parts[1]} pennies.";
            if (parts[0] != 0 && parts[1] == 0)
                return $"Your balance: {parts[0]} AM$.";
            return AmountOfMoney.ToString();
        }
    }
}