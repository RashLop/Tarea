using System.Data.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProyectoTecWeb.Models;
using ProyectoTecWeb.Models.DTO;
using ProyectoTecWeb.Repository;

namespace ProyectoTecWeb.Services
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository _repo; 
        public StudentService(IStudentRepository repo) => _repo = repo; 

        public async Task<StudentResponse> GetOneStudent(Guid id)
        {
            var doc = await _repo.GetStudent(id); 
            if(doc is null) throw new ArgumentException("Student not found"); 
            var response = new StudentResponse
            {
                StudentId = doc.StudentId,
                Name = doc.Name,
                Phone = doc.Phone,
                Specialty = doc.Specialty
            }; 
            return response; 
        } 
        public async Task<IEnumerable<StudentResponse>> GetAllStudents()
        {
            var items = await _repo.GetAllStudentsAsync(); 
            var response = items.Select(doc => new StudentResponse
            {
                StudentId = doc.StudentId,
                Name = doc.Name,
                Phone = doc.Phone,
                Specialty = doc.Specialty
            }); 
            return response; 
        } 

        public async Task<Student> CreateStudent(CreateStudentDto dto)
        {
            
            var created = new Student
            {
                StudentId = Guid.NewGuid(),
                UserId = dto.UserId,
                Name = dto.Name,
                Phone = dto.Phone,
                Specialty = dto.Specialty
            }; 
            await _repo.AddAsync(created); 
            await _repo.SaveChangesAsync(); 
            return created; 
        } 

        public async Task<Student> UpdateStudent( UpdateStudentDto dto, Guid id)
        {
            var Student = await _repo.GetStudent(id);
            if(Student is null) throw new ArgumentException("Student not found");  
            Student.Name = dto.Name;
            Student.Phone = dto.Phone; 
            await _repo.UpadteAsync(Student); 
            return Student; 
        }

        public async Task Delete(Guid id)
        {
            var deleted = await _repo.GetStudent(id); 
            if(deleted is null) throw new ArgumentException("Student not found"); 
            await _repo.DeleteAsync(deleted); 
        }
    }
}