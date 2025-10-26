using Class_Family.Models;
using Class_Family.Helpers;
using System.Linq;

namespace Class_Family.Views
{
    public partial class BoletimPage : ContentPage
    {
        private readonly DatabaseService _db;
        private readonly Usuario _usuario;

        public BoletimPage(DatabaseService db, Usuario usuario)
        {
            InitializeComponent();
            _db = db;
            _usuario = usuario;
            CarregarBoletim();
        }

        private async void CarregarBoletim()
        {
            // O ideal é filtrar por AlunoId aqui, mas mantido o ListarBoletins() original por enquanto.
            boletimList.ItemsSource = await _db.ListarBoletins();
        }
    }
}