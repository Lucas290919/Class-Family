using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Class_Family.Models
{
    public class Boletim
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int AlunoId { get; set; } // FK -> Aluno

        [Indexed]
        public int DisciplinaId { get; set; } // FK -> Disciplina

        public double Nota { get; set; }
    }
}
