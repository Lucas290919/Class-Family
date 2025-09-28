using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Class_Family.Models
{
    public class Disciplina
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nome { get; set; }

        [Indexed]
        public int ProfessorId { get; set; } // FK -> Professor

        [Indexed]
        public int TurmaId { get; set; } // FK -> Turma
    }
}
