using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public IActionResult GetView()
        {
            try
            {

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
            try
            {
                return Ok(await groupService.GetGroupById(Id));
            }
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

        [HttpGet("/index")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/check2")]
        public ActionResult Index23232(int page)
        {
            var groups  = new List<BusinessLogicLayer.DTO.GroupDTO>();
            groups = groupService.GetAllGroups().Result.ToList();

            int pageSize = 5;
            IEnumerable<BusinessLogicLayer.DTO.GroupDTO> groupsPerPages = groups.Skip((page - 1) * pageSize).Take(pageSize);
            
            return Ok(groupsPerPages);
        }
    }
}
