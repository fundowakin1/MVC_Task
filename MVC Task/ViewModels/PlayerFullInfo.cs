﻿using System.Collections.Generic;
using MVC_Task.Models;

namespace MVC_Task.ViewModels
{
    public class PlayerFullInfo
    {
        public List<Player> Players { get; set; }
        public List<PlayerInfo> PlayersInfo { get; set; }
    }
}
