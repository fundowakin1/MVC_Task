using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using MVC_Task.Models;

namespace MVC_Task.Seed
{
    public class MemberSeed
    {
        private static readonly MemberInfo[] Members = {
                new() {MemberId = 1, AmountOfMoney = 30, Name = "Joel Martin" , IsMage = false, IsVampire = false},
                new() {MemberId = 2, AmountOfMoney = 20, Name = "Christopher Washington" , IsMage = false, IsVampire = false},
                new() {MemberId = 3, AmountOfMoney = 12, Name = "Jaever Ricwil" , IsMage = false, IsVampire = false},
                new() {MemberId = 4, AmountOfMoney = 19, Name = "Thonygard Da" , IsMage = false, IsVampire = false},
                new() {MemberId = 5, AmountOfMoney = 10, Name = "Symes Neve" , IsMage = false, IsVampire = false},
                new() {MemberId = 6, AmountOfMoney = 10, Name = "Gilex Albyng" , IsMage = false, IsVampire = false},
                new() {MemberId = 7, AmountOfMoney = 10, Name = "Waltin Halle" , IsMage = false, IsVampire = false},
                new() {MemberId = 8, AmountOfMoney = 10, Name = "Gileon Awlys" , IsMage = false, IsVampire = false},
                new() {MemberId = 9, AmountOfMoney = 10, Name = "Cuthmund" , IsMage = false, IsVampire = false},
                new() {MemberId = 10, AmountOfMoney = 10, Name = "Jamart Merde", IsMage = false, IsVampire = false},
                new() {MemberId = 11, AmountOfMoney = 3, Name = "Twitcher", IsMage = false, IsVampire = false},
                new() {MemberId = 12, AmountOfMoney = 2, Name = "Drooler", IsMage = false, IsVampire = false},
                new() {MemberId = 13, AmountOfMoney = 1, Name = "Dribbler", IsMage = false, IsVampire = false},
                new() {MemberId = 14, AmountOfMoney = 1, Name = "Mumbler", IsMage = false, IsVampire = false},
                new() {MemberId = 15, AmountOfMoney = 0.9m, Name = "Mutterer", IsMage = false, IsVampire = false},
                new() {MemberId = 16, AmountOfMoney = 0.8m, Name = "Walking-Along-Shouter", IsMage = false, IsVampire = false},
                new() {MemberId = 17, AmountOfMoney = 0.6m, Name = "Demander of a Chip", IsMage = false, IsVampire = false},
                new() {MemberId = 18, AmountOfMoney = 0.5m, Name = "Person Who Call Other People Jimmy", IsMage = false, IsVampire = false},
                new() {MemberId = 19, AmountOfMoney = 0.08m, Name = "Person Who Need Eightpence For A Meal", IsMage = false, IsVampire = false},
                new() {MemberId = 20, AmountOfMoney = 0.02m, Name = "Person Who Need Tuppence For A Cup Of Tea", IsMage = false, IsVampire = false},
                new() {MemberId = 21, AmountOfMoney = 0, Name = "Person With Placards Saying \"Why lie? I need a beer.\"", IsMage = false, IsVampire = false},
                new() {MemberId = 22, AmountOfMoney = 0.5m, Name = "Muggins", IsMage = false, IsVampire = false},
                new() {MemberId = 23, AmountOfMoney = 1, Name = "Gull", IsMage = false, IsVampire = false},
                new() {MemberId = 24, AmountOfMoney = 2, Name = "Dupe", IsMage = false, IsVampire = false},
                new() {MemberId = 25, AmountOfMoney = 3, Name = "Butt", IsMage = false, IsVampire = false},
                new() {MemberId = 26, AmountOfMoney = 5, Name = "Fool", IsMage = false, IsVampire = false},
                new() {MemberId = 27, AmountOfMoney = 6, Name = "Tomfool", IsMage = false, IsVampire = false},
                new() {MemberId = 28, AmountOfMoney = 7, Name = "Stupid Fool", IsMage = false, IsVampire = false},
                new() {MemberId = 29, AmountOfMoney = 8, Name = "Arch Fool", IsMage = false, IsVampire = false},
                new() {MemberId = 30, AmountOfMoney = 10, Name = "Complete Fool", IsMage = false, IsVampire = false}
            };

        private const int QuantityOfVampires = 4;
        private const int QuantityOfMages = 4;   
        public static void Seeding(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Member>().HasData(new Member[]
            {
                new() {Id = 1, GuildId = 1},
                new() {Id = 2, GuildId = 1},
                new() {Id = 3, GuildId = 1},
                new() {Id = 4, GuildId = 1},
                new() {Id = 5, GuildId = 2},
                new() {Id = 6, GuildId = 2},
                new() {Id = 7, GuildId = 2},
                new() {Id = 8, GuildId = 2},
                new() {Id = 9, GuildId = 2},
                new() {Id = 10, GuildId = 2},
                new() {Id = 11, GuildId = 3},
                new() {Id = 12, GuildId = 3},
                new() {Id = 13, GuildId = 3},
                new() {Id = 14, GuildId = 3},
                new() {Id = 15, GuildId = 3},
                new() {Id = 16, GuildId = 3},
                new() {Id = 17, GuildId = 3},
                new() {Id = 18, GuildId = 3},
                new() {Id = 19, GuildId = 3},
                new() {Id = 20, GuildId = 3},
                new() {Id = 21, GuildId = 3},
                new() {Id = 22, GuildId = 4},
                new() {Id = 23, GuildId = 4},
                new() {Id = 24, GuildId = 4},
                new() {Id = 25, GuildId = 4},
                new() {Id = 26, GuildId = 4},
                new() {Id = 27, GuildId = 4},
                new() {Id = 28, GuildId = 4},
                new() {Id = 29, GuildId = 4},
                new() {Id = 30, GuildId = 4}
            });
            ChoosingVampireAndMage();
            modelBuilder.Entity<MemberInfo>().HasData(Members);
        }

        private static void ChoosingVampireAndMage()
        {
            var counter = 0;
            while (counter < QuantityOfVampires+QuantityOfMages)
            {
                var random = RandomNumberGenerator.GetInt32(1, Members.Length);
                if (Members[random].IsVampire==false && counter<QuantityOfVampires)
                {
                    counter++;
                    Members[random].IsVampire = true;
                }
                else if (Members[random].IsMage==false)
                {
                    counter++;
                    Members[random].IsMage = true;
                }
            }
        }
    }
}