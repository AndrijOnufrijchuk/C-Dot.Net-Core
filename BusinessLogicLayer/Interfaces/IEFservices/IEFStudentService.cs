using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.services
{
    public interface IEFStudentService
    {
        
        Task AddStudent(StudentDTO student);

        Task UpdateStudent(StudentDTO student);

        Task DeleteStudent(int Id);

        Task<StudentDTO> GetStudentById(int Id);

        Task<IEnumerable<StudentDTO>> GetAllStudents();

        Task<StudentDTO> GetStudentByName(string name);

    }
}
