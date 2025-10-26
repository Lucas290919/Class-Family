using SQLite;

namespace Class_Family.Models
{
    public class Aluno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int UsuarioId { get; set; }
        public string Matricula { get; set; }
        [Indexed]
        public int TurmaId { get; set; } 
    }
}
