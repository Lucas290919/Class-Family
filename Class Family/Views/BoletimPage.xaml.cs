using Class_Family.Models;
using Class_Family.Helpers;
using System.Linq;
using System.Collections.Generic;

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

            if (_usuario.Tipo == "Professor")
            {
                AtribuirNotaButton.IsVisible = true;
            }

            CarregarBoletim();
        }

        private async void CarregarBoletim()
        {
            List<Boletim> todosBoletins = await _db.ListarBoletins();
            IEnumerable<Boletim> boletimFiltrado = new List<Boletim>();

            if (_usuario.Tipo == "Aluno" || _usuario.Tipo == "Responsável")
            {
                // CORREÇÃO: Busca o registro Aluno usando o ID do usuário logado
                var alunoLogado = await _db.ObterAlunoPorUsuarioId(_usuario.Id);

                if (alunoLogado != null)
                {
                    // Filtra usando o AlunoId correto (o ID do registro Aluno)
                    boletimFiltrado = todosBoletins.Where(b => b.AlunoId == alunoLogado.Id);
                }
            }
            else // Professor, Administrador, etc. (Vê todos)
            {
                boletimFiltrado = todosBoletins;
            }

            // Note: Adicionamos um cast para ToList() para garantir que a CollectionView receba uma lista concreta
            boletimList.ItemsSource = boletimFiltrado.ToList();
        }

        private async void OnAtribuirNotaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AtribuirNotaPage(_db, _usuario));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CarregarBoletim();
        }
    }
}