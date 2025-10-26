    using Class_Family.Models;
using Class_Family.Helpers;
namespace Class_Family.Views;

public partial class HomePage : ContentPage
{
    private readonly DatabaseService _db;
    private readonly Usuario _usuario;

    public HomePage(DatabaseService db, Usuario usuario)
    {
        InitializeComponent();
        _db = db;
        _usuario = usuario;

        welcomeLabel.Text = $"Bem-vindo, {_usuario.Nome} ({_usuario.Tipo})";
    }

    private async void OnComunicadosClicked(object sender, EventArgs e)
        => await Navigation.PushAsync(new ComunicadosPage(_db));

    private async void OnBoletimClicked(object sender, EventArgs e)
        => await Navigation.PushAsync(new BoletimPage(_db));

    private async void OnAgendaClicked(object sender, EventArgs e)
        => await Navigation.PushAsync(new AgendaPage(_db));

    private async void OnSairClicked(object sender, EventArgs e)
        => await Navigation.PopToRootAsync();
}