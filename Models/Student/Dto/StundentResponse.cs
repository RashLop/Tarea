namespace ProyectoTecWeb.Models.DTO
{
    public class StudentResponse {
        public Guid StudentId {get; init;}
        public string Name {get; init; } = string.Empty; 
        public string Phone {get; init; } = string.Empty; 
        public string Specialty {get; init; } = string.Empty;
    }
}