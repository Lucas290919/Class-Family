using SQLite;
namespace Class_Family.Models
{
    public class AlunoResponsavel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int AlunoID { get; set; }

        [Indexed]
        public int ResponsavelID { get; set; }
    }
}
