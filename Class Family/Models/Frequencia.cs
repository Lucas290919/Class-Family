using SQLite;

namespace Class_Family.Models
{
    public class Frequencia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int AlunoId { get; set; } // FK -> Aluno

        [Indexed]
        public int ProfessorId { get; set; } // FK -> Professor

        public DateTime Data { get; set; }

        public bool Presente { get; set; }
    }
}
