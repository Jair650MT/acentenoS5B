using acentenoS5B.Model;
using acentenoS5B.Untils;
using Microsoft.Extensions.Logging;

namespace acentenoS5B
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

            string dbPath = FileAccessHelper.GetLocalFilePath("personas.db3");
#if DEBUG
            builder.Services.AddSingleton<PersonaRepository>(s =>ActivatorUtilities.CreateInstance<PersonaRepository>(s,dbPath));
#endif

            return builder.Build();
        }
    }
}
