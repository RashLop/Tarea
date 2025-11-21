using Microsoft.AspNetCore.Http.HttpResults;
using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;

namespace ProyectoTecWeb.Services
{
    public interface IStudentService
    {
        Task<StudentResponse> GetOneStudent(Guid id); 
        Task<IEnumerable<StudentResponse>> GetAllStudents(); 

        Task<Student> CreateStudent(CreateStudentDto dto); 

        Task<Student> UpdateStudent(UpdateStudentDto dto, Guid id); 

        Task Delete (Guid id); 

    }
}