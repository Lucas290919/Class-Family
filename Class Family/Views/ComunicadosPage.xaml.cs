using Class_Family.Models;
using Class_Family.Helpers;
using System;

namespace Class_Family.Views
{
    public partial class ComunicadosPage : ContentPage
    {
        private readonly DatabaseService _db;
        private readonly Usuario _usuario;

        public ComunicadosPage(DatabaseService db, Usuario usuario)
        {
            InitializeComponent();
            _db = db;
            _usuario = usuario;

            if (_usuario.Tipo == "Aluno" || _usuario.Tipo == "Responsável")
            {
                ComunicationControls.IsVisible = false;
            }

            CarregarComunicados();
        }

        private async void OnEnviarClicked(object sender, EventArgs e)
        {
            var novo = new Comunicado
            {
                Titulo = tituloEntry.Text,
                Mensagem = mensagemEditor.Text,
                DataEnvio = DateTime.Now,
                Remetente = _usuario.Nome
            };

            await _db.SalvarComunicado(novo);
            await DisplayAlert("Sucesso", "Comunicado enviado!", "OK");

            tituloEntry.Text = string.Empty;
            mensagemEditor.Text = string.Empty;

            CarregarComunicados();
        }

        private async void CarregarComunicados()
        {
            comunicadosList.ItemsSource = await _db.ListarComunicados();
        }
    }
}