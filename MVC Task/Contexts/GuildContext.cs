using Microsoft.EntityFrameworkCore;
using MVC_Task.Models;
using MVC_Task.Seed;

namespace MVC_Task.Contexts
{
    public class GuildContext : DbContext
    {
        public DbSet<Guild>Guilds { get; set; }
        public DbSet<Member>Members { get; set; }
        public DbSet<MemberInfo>MembersInfo { get; set; }
        public GuildContext(DbContextOptions<GuildContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder Options)  
        {
            Options.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guild>().HasKey(guild => guild.Id);
            modelBuilder.Entity<Member>().HasKey(member => member.Id);
            modelBuilder.Entity<MemberInfo>().HasKey(memberInfo => memberInfo.MemberId);
            
            modelBuilder.Entity<Member>().HasOne(x => x.GuildEntity)
                .WithMany(y => y.Members).HasForeignKey(k => k.GuildId);
            
            modelBuilder.Entity<MemberInfo>().HasOne(x => x.MemberEntity)
                .WithOne(y => y.MemberInfoEntity).HasForeignKey<MemberInfo>(k => k.MemberId);
            
            GuildSeed.Seeding(modelBuilder);
            MemberSeed.Seeding(modelBuilder);
        }
    }
}