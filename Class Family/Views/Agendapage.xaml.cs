using Class_Family.Models;
using Class_Family.Helpers;
using System;

namespace Class_Family.Views
{
    public partial class AgendaPage : ContentPage
    {
        private readonly DatabaseService _db;
        private readonly Usuario _usuario;

        public AgendaPage(DatabaseService db, Usuario usuario)
        {
            InitializeComponent();
            _db = db;
            _usuario = usuario;

            if (_usuario.Tipo == "Aluno" || _usuario.Tipo == "Responsável")
            {
                AgendaControls.IsVisible = false;
            }

            CarregarEventos();
        }

        private async void OnAdicionarClicked(object sender, EventArgs e)
        {
            var novoEvento = new Agenda
            {
                Evento = eventoEntry.Text,
                Descricao = descricaoEntry.Text,
                Data = dataPicker.Date
            };

            await _db.SalvarAgenda(novoEvento);
            await DisplayAlert("Sucesso", "Evento adicionado!", "OK");

            eventoEntry.Text = string.Empty;
            descricaoEntry.Text = string.Empty;

            CarregarEventos();
        }

        private async void CarregarEventos()
        {
            agendaList.ItemsSource = await _db.ListarEventos();
        }
    }
}