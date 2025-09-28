using SQLite;
namespace Class_Family.Models
{
    public class Professor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Indexed]
        public int UsuarioId { get; set; } // FK -> Usuario
        public string Disciplina { get; set; }
    }
}
