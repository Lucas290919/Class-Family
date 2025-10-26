using SQLite;

namespace Class_Family.Models
{
    public class Boletim
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int AlunoId { get; set; } 

        [Indexed]
        public int DisciplinaId { get; set; } 

        public double Nota { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataLancamento { get; set; } = DateTime.UtcNow;
    }
}
