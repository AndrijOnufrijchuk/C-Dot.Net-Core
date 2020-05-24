using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.services;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;





namespace BusinessLogicLayer.services
{
   public class EFStudentService : IEFStudentService
    {
        IUnitOfWork _efUnitOfWork;
        private readonly IMapper _mapper;

        public EFStudentService(IUnitOfWork efUnitOfWork, IMapper mapper)
        {
            _efUnitOfWork = efUnitOfWork;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var x = await _efUnitOfWork.EFStudentRepository.GetAll();
            List<StudentDTO> res = new List<StudentDTO>();
            foreach (var i in x)
                res.Add(_mapper.Map<Student, StudentDTO>(i));

            return res;
        }

        public async Task<StudentDTO> GetStudentById(int Id)
        {
            var x = await _efUnitOfWork.EFStudentRepository.Get(Id);
            StudentDTO res = _mapper.Map<Student, StudentDTO>(x);

            return res;
        }

        public async Task AddStudent(StudentDTO student)
        {
            var x = _mapper.Map<StudentDTO, Student>(student);
            await _efUnitOfWork.EFStudentRepository.Add(x);
        }

        public async Task DeleteStudent(int Id)
        { await _efUnitOfWork.EFStudentRepository.Delete(Id); }

        public async Task UpdateStudent(StudentDTO student)
        {
            var x = _mapper.Map<StudentDTO, Student>(student);
            await _efUnitOfWork.EFStudentRepository.Update(x);
        }

        public async Task<StudentDTO> GetStudentByName(string name)
        {
            var x = await _efUnitOfWork.EFStudentRepository.GetStudentByName(name);
            StudentDTO res = _mapper.Map<Student, StudentDTO>(x);

            return res;
        }
    }
}
