using Class_Family.Models;
using Class_Family.Helpers;
namespace Class_Family.Views;

public partial class BoletimPage : ContentPage
{
    private readonly DatabaseService _db;

    public BoletimPage(DatabaseService db)
    {
        InitializeComponent();
        _db = db;
        CarregarBoletim();
    }

    private async void CarregarBoletim()
    {
        boletimList.ItemsSource = await _db.ListarBoletins();
    }
}