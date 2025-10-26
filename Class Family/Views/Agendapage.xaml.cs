using Class_Family.Models;
using Class_Family.Helpers;
namespace Class_Family.Views;
public partial class AgendaPage : ContentPage
{
    private readonly DatabaseService _db;

    public AgendaPage(DatabaseService db)
    {
        InitializeComponent();
        _db = db;
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
        CarregarEventos();
    }

    private async void CarregarEventos()
    {
        agendaList.ItemsSource = await _db.ListarEventos();
    }
}