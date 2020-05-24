using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IEFRepos
{
    public interface IEFStudentRepo : IGenericRepository<Student, int>
    {

        Task<Student> GetStudentByName(string name);
    }
}
