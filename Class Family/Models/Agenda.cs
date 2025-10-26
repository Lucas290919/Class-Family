using SQLite;

namespace Class_Family.Models
{
    public class Agenda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Evento { get; set; }
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
    }
}
