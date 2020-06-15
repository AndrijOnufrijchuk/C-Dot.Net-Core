using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.services;
using BusinessLogicLayer.services;
using DataAccessLayer.DbContext1;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            try { 

                return Ok(await studentService.GetAllStudents()); 
            }
            catch { return StatusCode(404); }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try { return Ok(await studentService.GetStudentById(Id)); }
            catch { return StatusCode(404); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await studentService.DeleteStudent(id);
                return Ok();
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

    /*    MyDbContext db = new MyDbContext();

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(db.Students.Find(id));
        }

        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "id", "group_number");
            return View();
        }


        public ActionResult Edit(int id)
        {
            return View(db.Students.Where(x => x.id == id).FirstOrDefault());
        }


        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {

                db.Students.Add(student);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(StudentDTO student)
        {
            try
            {


                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(StudentDTO student)
        {
            try
            {

                db.Entry(student).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/

    }

}
/*
 
*/

