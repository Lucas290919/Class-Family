using Class_Family.Models;
using Class_Family.Helpers;
namespace Class_Family.Views;

public partial class ComunicadosPage : ContentPage
{
    private readonly DatabaseService _db;

    public ComunicadosPage(DatabaseService db)
    {
        InitializeComponent();
        _db = db;
        CarregarComunicados();
    }

    private async void OnEnviarClicked(object sender, EventArgs e)
    {
        var novo = new Comunicado
        {
            Titulo = tituloEntry.Text,
            Mensagem = mensagemEditor.Text,
            DataEnvio = DateTime.Now,
            Remetente = "Professor"
        };

        await _db.SalvarComunicado(novo);
        await DisplayAlert("Sucesso", "Comunicado enviado!", "OK");
        CarregarComunicados();
    }

    private async void CarregarComunicados()
    {
        comunicadosList.ItemsSource = await _db.ListarComunicados();
    }
}