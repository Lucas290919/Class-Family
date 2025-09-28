using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Class_Family.Models
{
    public class Aluno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int UsuarioId { get; set; } // FK -> Usuario

        public string Matricula { get; set; }

        [Indexed]
        public int TurmaId { get; set; } // FK -> Turma
    }
}
