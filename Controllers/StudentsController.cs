using AlunosApi.Models;
using AlunosApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentsService _studentsService;
        public StudentsController(IStudentsService studentsService)
        {
            _studentsService= studentsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<StudentModel>>> GetStudents()
        {
            try
            {
                var students = await _studentsService.GetStudents();
                return Ok(students);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter alunos");
            }
        }

        [HttpGet("StudentByName")]
        public async Task<ActionResult<IAsyncEnumerable<StudentModel>>> GetStudentByName([FromQuery] string name)
        {
            try
            {
                var student = await _studentsService.GetStudentByName(name);
                if (student.Count() == 0)
                    return NotFound($"Não existe alunos com o critério {name}");

                return Ok(student);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter o aluno");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudenty(StudentModel student)
        {
            try
            {
                await _studentsService.CreateStudent(student);
                return CreatedAtRoute(nameof(GetStudents), new {id = student.StudentId}, student);
            }
            catch
            {
                return BadRequest("Invalid request");
            }
        }
    }
}
