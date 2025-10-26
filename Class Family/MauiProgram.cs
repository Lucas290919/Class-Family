using Microsoft.Extensions.Logging;
using Class_Family.Helpers;
using Class_Family.Views;

namespace Class_Family
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            const string DatabaseFilename = "ClassFamily.db3";
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
            builder.Services.AddSingleton<DatabaseService>(s => new DatabaseService(dbPath));
            builder.Services.AddTransient<Page_Login>();
            builder.Services.AddTransient<CadastroPage>();
            builder.Services.AddTransient<HomePage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
