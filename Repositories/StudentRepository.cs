using Microsoft.EntityFrameworkCore;
using ProyectoTecWeb.Data;
using ProyectoTecWeb.Models;

namespace ProyectoTecWeb.Repository
{
    public class StudentRepository: IStudentRepository
    {
        private readonly AppDbContext _ctx;
        public StudentRepository(AppDbContext ctx)
        {
            _ctx = ctx; 
        }

        public Task<Student?> GetStudent(Guid id) => _ctx.Students.FirstOrDefaultAsync(x => x.StudentId == id); 
        public async Task AddAsync(Student Student)
        {
            await _ctx.Students.AddAsync(Student); 
        } 
        public async Task UpadteAsync(Student Student)
        {
            _ctx.Students.Update(Student);
            await _ctx.SaveChangesAsync(); 
        } 
        public async Task DeleteAsync(Student Student)
        {
            
            _ctx.Students.Remove(Student); 
            await _ctx.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()=> await _ctx.Students.ToListAsync();  

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync(); 
        }

        
    }
}