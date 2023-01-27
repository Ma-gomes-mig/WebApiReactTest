﻿using AlunosApi.Models;
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

        [HttpPut("{id = int")]
        public async Task<ActionResult> EditStudent(int id, [FromBody] StudentModel student)
        {
            try
            {
                if(student.StudentId == id)
                {
                    await _studentsService.UpdateStudent(student);
                    return Ok($"Student with id={id} get update");
                }
                else
                {
                    return BadRequest("Inconsistent data");
                }                
            }
            catch
            {
                return BadRequest("Invalid Request");
            }
        }

        [HttpDelete("{id=int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var student = await _studentsService.GetStudent(id);
                if(student != null)
                {
                    await _studentsService.DeleteStudent(student);
                    return Ok($"Student with id={id} was delete");
                }
                else
                {
                    return NotFound($"Student with id={id} not found");
                }
            }
            catch
            {
                return BadRequest("Invalid Request");
            }
        }

    }
}
