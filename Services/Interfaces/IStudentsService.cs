using AlunosApi.Models;
using System.Threading.Tasks;

namespace AlunosApi.Services.Interfaces    
{
    public interface IStudentsService
    {
        Task<IEnumerable<StudentModel>> GetStudents();
        Task<StudentModel> GetStudent(int id);
        Task<IEnumerable<StudentModel>> GetStudentByName(string name);
        Task CreateStudent(StudentModel student);
        Task UpdateStudent(StudentModel student);
        Task DeleteStudent(StudentModel student);
    }
}
