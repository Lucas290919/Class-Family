using SQLite;

namespace Class_Family.Models
{
    public class Responsavel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int UsuarioId { get; set; }

        public string NomeAluno { get; set; }
        public string Telefone { get; set; }
    }
}

