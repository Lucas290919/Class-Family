using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Class_Family.Models
{
    public class Comunicado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Mensagem { get; set; }

        public DateTime Data { get; set; }

        public string Remetente { get; set; } // "Professor" ou "Secretaria"
    }
}
