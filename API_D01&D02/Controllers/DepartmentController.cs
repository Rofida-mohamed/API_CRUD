using Api_D01.Models;
using Api_D01.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_D01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentRepo departmentRepo;


        public DepartmentController(IDepartmentRepo _departmentRepo)
        {

            departmentRepo = _departmentRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var depts = departmentRepo.GetAll();

            if (depts == null)
            {
                return NotFound();
            }

            return Ok(depts);
        }
        [HttpGet("{id:int}", Name = "GetOneDept")]
        public IActionResult GetbyId(int id)
        {
            var dept = departmentRepo.GetById(id);
            if (dept == null)
            {
                return NotFound(new { msg = $"Department with id {id} not found " });
            }
            return Ok(new { msg = $"Department with id {id} is found", std = dept });
        }
        [HttpPost]
        public IActionResult add(Department dept)
        {

            if (ModelState.IsValid)
            {
                departmentRepo.Add(dept);
                string URL = Url.Link("GetOneDept", new { id = dept.id });
                return Created(URL, "");
            }

            return BadRequest();

        }
        [HttpPut("{id}")]
        public IActionResult update(int id, Department dept)
        {

            if (ModelState.IsValid)
            {
                departmentRepo.Update(id, dept);

                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dept = departmentRepo.GetById(id);

            if (dept == null)
            {
                return NotFound();
            }
            else
            {
                departmentRepo.Delete(id);
                return Ok(dept);
            }
        }
    }
}
