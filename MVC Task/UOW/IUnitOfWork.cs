using MVC_Task.Interfaces;

namespace MVC_Task.UOW
{
    public interface IUnitOfWork
    {
        public IGuildRepository GuildRepository { get;}
        public IMemberRepository MemberRepository { get;}
        public IMemberInfoRepository MemberInfoRepository { get;}
        public IPlayerRepository PlayerRepository { get;}
        public IPlayerInfoRepository PlayerInfoRepository { get; }
    }
}
