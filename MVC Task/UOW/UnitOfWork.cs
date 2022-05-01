using MVC_Task.Contexts;
using MVC_Task.Interfaces;
using MVC_Task.Repositories;

namespace MVC_Task.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private PlayerContext _playerContext;
        private GuildContext _guildContext;

        public UnitOfWork(PlayerContext playerContext, GuildContext guildContext)
        {
            _playerContext = playerContext;
            _guildContext = guildContext;
        }

        private IGuildRepository _guildRepository;
        private IMemberRepository _memberRepository;
        private IMemberInfoRepository _memberInfoRepository;
        private IPlayerRepository _playerRepository;
        private IPlayerInfoRepository _playerInfoRepository;

        public IGuildRepository GuildRepository => _guildRepository ??= new GuildRepository(_guildContext);
        public IMemberRepository MemberRepository => _memberRepository ??= new MemberRepository(_guildContext);
        public IMemberInfoRepository MemberInfoRepository => _memberInfoRepository ??= new MemberInfoRepository(_guildContext);
        public IPlayerRepository PlayerRepository => _playerRepository ??= new PlayerRepository(_playerContext);
        public IPlayerInfoRepository PlayerInfoRepository => _playerInfoRepository ??= new PlayerInfoRepository(_playerContext);
    }
}
