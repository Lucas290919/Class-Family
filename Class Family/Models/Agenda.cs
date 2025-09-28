using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Class_Family.Models
{
    public class Agenda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Evento { get; set; }

        public DateTime Data { get; set; }

        public string Local { get; set; }
    }
}
