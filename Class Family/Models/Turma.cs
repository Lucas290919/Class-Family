using SQLite;

namespace Class_Family.Models
{
    public class Turma
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
