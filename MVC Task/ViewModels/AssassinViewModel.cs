using System.Collections.Generic;

namespace MVC_Task.ViewModels
{
    public class AssassinViewModel
    {
        public Dictionary<int, InfoAboutAssassin> OccupationDictionary { get; set; }
       
        public decimal InputtedAmountOfMoney { get; set; }

        public CharacterViewModel Character { get; set; }
        public class InfoAboutAssassin
        {
            public bool IsOccupied { get; set; }
            public decimal LowerFeeBound { get; set; }
            public decimal UpperFeeBound { get; set; }

            public InfoAboutAssassin(bool isOccupied, decimal lowerFeeBound, decimal upperFeeBound)
            {
                IsOccupied = isOccupied;
                LowerFeeBound = lowerFeeBound;
                UpperFeeBound = upperFeeBound;
            }
        }
    }
}
