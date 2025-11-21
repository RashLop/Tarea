using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repository
{
    public interface IStudentRepository
    {
        Task<Student?> GetStudent(Guid id); 
        Task AddAsync(Student Student); 
        Task UpadteAsync(Student Student); 
        Task DeleteAsync(Student Student); 
        Task<IEnumerable<Student>> GetAllStudentsAsync(); 

        Task SaveChangesAsync(); 
    }
}