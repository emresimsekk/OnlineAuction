using OnlineAuction.Core.Entities;
using OnlineAuction.Core.Repositories;
using OnlineAuction.Infrastructure.Data;
using OnlineAuction.Infrastructure.Repository.Base;

namespace OnlineAuction.Infrastructure.Repository
{
    public class UserRepository:Repository<AppUser>,IUserRepository
    {
        private readonly WebAppContext _context;

        public UserRepository(WebAppContext context ):base(context)
        {
            _context = context;
        }
    }
}
