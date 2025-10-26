using SQLite;

namespace Class_Family.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }    
        public string Senha { get; set; }


    }
}
