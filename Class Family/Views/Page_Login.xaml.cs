using Class_Family.Helpers;
namespace Class_Family.Views;

public partial class Page_Login : ContentPage
{
    private readonly DatabaseService _db;
    public Page_Login(DatabaseService db)
	{
		InitializeComponent( );

		_db = db;
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var usuarios = await _db.ListarUsuarios();
        var usuario = usuarios.FirstOrDefault(u => u.Email == emailEntry.Text && u.Senha == senhaEntry.Text);

        if (usuario != null)
        {
            await DisplayAlert("Sucesso", $"Bem-vindo, {usuario.Nome}!", "OK");
            var dbService = ServiceHelper.GetService<DatabaseService>();
            await Navigation.PushAsync(new HomePage(dbService, usuario));
        }
        else
        {
            await DisplayAlert("Erro", "Email ou senha incorretos.", "OK");
        }
    }

    private async void OnCadastroClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(ServiceHelper.GetService<CadastroPage>());
    }
}