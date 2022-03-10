using OnlineAuction.Core.Entities;
using OnlineAuction.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuction.Core.Repositories
{
   public interface IUserRepository: IRepository<AppUser>
    {
    }
}
