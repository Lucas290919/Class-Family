using SQLite;
namespace Class_Family.Models

    {
        public class Professor
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            [Indexed]
            public int UsuarioId { get; set; }

            public string Materia { get; set; }
            public string Telefone { get; set; }
        }
    }

