using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace University.controllers
{
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        IEFGroupService groupService;

        public GroupController(IEFGroupService _groupService)
        {
            groupService = _groupService;
        }




        [HttpGet]
        public async Task<IActionResult> GetView()
        {
            try {
               
                return View();
            }
            catch { return StatusCode(404); }
        }

        [HttpGet("/check")]
        public async Task<IActionResult> GetJson()
        {
            try
            {
                
                return Ok(await groupService.GetAllGroups());
            }
            catch { return StatusCode(404); }
        }


        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try { return Ok(await groupService.GetGroupById(Id)); }
            catch { return StatusCode(404); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await groupService.DeleteGroup(Id);
                return StatusCode(200);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GroupDTO val)
        {
            try
            {
                await groupService.UpdateGroup(val);
                return StatusCode(204);
            }
            catch
            { return StatusCode(404); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroupDTO val)
        {
            try
            {
                await groupService.AddGroup(val);
                return StatusCode(201);
            }
            catch
            {
               
                return StatusCode(404);
                
            }
        }

        public ActionResult Index()
        {
            return View();
        }




    }
}
