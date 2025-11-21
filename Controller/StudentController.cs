using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Services;

namespace ProyectoTecWeb.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _doc; 

        public StudentController(IStudentService doc)
        {
            _doc = doc; 
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOneStudent(Guid id)
        {
            var Student = await _doc.GetOneStudent(id); 
            return Ok(Student); 
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
        { if(!ModelState.IsValid) return ValidationProblem(ModelState); 
            var created = await _doc.CreateStudent(dto); 
            return CreatedAtAction(nameof(GetOneStudent), new {id = created.StudentId}, created); 
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<StudentResponse> items =await _doc.GetAllStudents(); 
            return Ok(items); 
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentDto dto, Guid id)
        {
            if(!ModelState.IsValid) return ValidationProblem(ModelState); 
            var Update = await _doc.UpdateStudent(dto, id); 
            return CreatedAtAction(nameof(GetOneStudent), new {id = Update.StudentId}, Update); 
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _doc.Delete(id); 
            return NoContent(); 
        }
    }
    
}