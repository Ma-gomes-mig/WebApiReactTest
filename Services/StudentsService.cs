using AlunosApi.Context;
using AlunosApi.Models;
using AlunosApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StudentModel>> GetStudents()
        {
            try
            {
                return await _dbContext.Students.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<StudentModel>> GetStudentByName(string name)
        {
            try
            {
                IEnumerable<StudentModel> student;
                if(!string.IsNullOrWhiteSpace(name)) 
                {
                    student = await _dbContext.Students.Where(n => n.StudentName == name).ToListAsync();
                }
                else
                {
                    student = await GetStudents();
                }
                return student;
            }
            catch
            {
                throw;
            }
        }

        public async Task<StudentModel> GetStudent(int id)
        {
            try
            {
                var student = await _dbContext.Students.FindAsync(id);
                return student;
            }
            catch
            {
                throw;
            }
        }
        public async Task CreateStudent(StudentModel student)
        {
            try
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            
        }

        public async Task UpdateStudent(StudentModel student)
        {
            _dbContext.Entry(student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(StudentModel student)
        {
            try
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }        
    }
}
