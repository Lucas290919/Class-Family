using SQLite;

namespace Class_Family.Models
{
    public class Comunicado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Mensagem { get; set; }

        public DateTime DataEnvio { get; set; }

        public string Remetente { get; set; } // "Professor" ou "Secretaria"
    }
}
