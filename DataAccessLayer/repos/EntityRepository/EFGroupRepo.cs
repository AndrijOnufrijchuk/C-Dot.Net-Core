using DataAccessLayer.DbContext1;
using DataAccessLayer.Interfaces.IEFRepos;
using DataAccessLayer.Entities;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = DataAccessLayer.Entities.Group;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer.repos.EntityRepository
{
   public class EFGroupRepo : GenericRepository<Entities.Group, int>, IEFGroupRepo
    {


        public EFGroupRepo (MyDbContext dbcontext)
          : base(dbcontext)
        { }

      
    }
}
