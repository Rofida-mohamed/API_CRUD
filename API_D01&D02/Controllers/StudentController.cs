using Api_D01.Models;
using Api_D01.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_D01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentRepo studentRepo;
        

        public StudentController( IStudentRepo _studentRepo)
        {
            
            studentRepo = _studentRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stds = studentRepo.GetAll();

            if (stds == null)
            {
                return NotFound();
            }

            return Ok(stds);
        }
        [HttpGet("{id:int}",Name ="GetOne")]
        public IActionResult GetbyId(int id)
        {
            var std = studentRepo.GetById(id);
            if (std == null)
            {
                return NotFound(new { msg = $"student with id {id} not found " });
            }
            return Ok(new { msg = $"student with id {id} is found", std = std });
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetbyName(string name) 
        {
            var std = studentRepo.GetByName(name);
            if (std == null)
            {
                return NotFound(new { msg = $"Student with name {name} not found " });
            }
            return Ok(new { msg = $"student with name {name} is found", std = std });
        }
        [HttpPost]
        public IActionResult add(Student std) 
        {
            
            if (ModelState.IsValid)
            {
                studentRepo.Add(std);
                string URL = Url.Link("GetOne",new {id = std.id});
                return Created(URL,"");
            }

            return BadRequest();
          
        }
        [HttpPut("{id}")]
        public IActionResult update(int id, Student std) 
        {
            
            if (ModelState.IsValid) 
            {
                studentRepo.Update(id,std);
                
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var std = studentRepo.GetById(id);

            if (std == null)
            {
                return NotFound();
            }
            else
            {
                studentRepo.Delete(id);
                return Ok(std);
            }
        }
    }
}
