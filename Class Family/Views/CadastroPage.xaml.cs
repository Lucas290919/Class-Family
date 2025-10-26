using Class_Family.Helpers;
using Class_Family.Models;
namespace Class_Family.Views;

public partial class CadastroPage : ContentPage
{
    private readonly DatabaseService _db;

    public CadastroPage(DatabaseService db)
    {
        InitializeComponent();
        _db = db;
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        var novoUsuario = new Usuario
        {
            Nome = nomeEntry.Text,
            Email = emailEntry.Text,
            Senha = senhaEntry.Text,
            Tipo = tipoPicker.SelectedItem?.ToString()
        };
        try
        {
            await _db.SalvarUsuario(novoUsuario);
            await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex) 
        {
            DisplayAlert("ERRO", ex.Message, "Okk");
        }

    }
}