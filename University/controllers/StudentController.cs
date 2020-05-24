using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.services;
using BusinessLogicLayer.services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace University.controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        IEFStudentService studentService;


        public StudentController(IEFStudentService efstudentService)
        {
            studentService = efstudentService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try { return Ok(await studentService.GetAllStudents()); }
            catch { return StatusCode(404); }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try { return Ok(await studentService.GetStudentById(Id)); }
            catch { return StatusCode(404); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await studentService.DeleteStudent(Id);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StudentDTO val)
        {
            try
            {
                await studentService.UpdateStudent(val);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentDTO val)
        {
            try
            {
                await studentService.AddStudent(val);
                return StatusCode(201);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try { return Ok(await studentService.GetStudentByName(name)); }
            catch { return StatusCode(404); }
        }



    }
}