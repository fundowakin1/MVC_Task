using Microsoft.EntityFrameworkCore;
using MVC_Task.Models;

namespace MVC_Task.Contexts
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player>Players { get; set; }
        public DbSet<PlayerInfo>PlayersInfo { get; set; }
        
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder Options)  
        {
            Options.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasKey(player => player.Id);
            modelBuilder.Entity<PlayerInfo>().HasKey(playerInfo => playerInfo.PlayerId);
            
            modelBuilder.Entity<PlayerInfo>().HasOne(x => x.Player)
                .WithOne(y => y.PlayerInfoEntity).HasForeignKey<PlayerInfo>(k => k.PlayerId);
        }
    }
}