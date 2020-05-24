using DataAccessLayer.DbContext1;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IEFRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.repos.EntityRepository
{
    public class EFStudentRepo : GenericRepository<Student, int>, IEFStudentRepo
    {
        public EFStudentRepo(MyDbContext dbcontext)
           : base(dbcontext)
        { }

        public async Task<Student> GetStudentByName(string name)
        {
            var x = await _dbcontext.Set<Student>().ToListAsync();

            return x.Where(x => x.name == name).FirstOrDefault();
        }
    }
}
