using Class_Family.Helpers;
using Class_Family.Views;

namespace Class_Family;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Define a página inicial do aplicativo
        MainPage = new NavigationPage(
            new Page_Login(ServiceHelper.GetService<DatabaseService>())
        );
    }
}