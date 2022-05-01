using Microsoft.EntityFrameworkCore;
using MVC_Task.Models;

namespace MVC_Task.Seed
{
    public class GuildSeed
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guild>().HasData(new Guild[]
            {
                new Guild {Id = 1, Name = "Ankh-Morpork Assassins' Guild"},
                new Guild {Id = 2, Name = "Guild of Thieves, Cutpurses and Allied Trades"},
                new Guild {Id = 3, Name = "Ankh-Morpork Beggars' Guild"},
                new Guild {Id = 4, Name = "The Guild of Fools and Joculators and College of Clowns"}
            });
        }
    }
}