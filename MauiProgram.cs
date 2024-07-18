using Microsoft.Extensions.Logging;
using ProtoDevDemo.Repositories;

namespace ProtoDevDemo
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Add this code
            string dbPath = FileAccessHelper.GetLocalFilePath("prueba.db3");
            Console.WriteLine(dbPath);

            builder.Services.AddSingleton<ProtoBDRepo>(s => ActivatorUtilities.CreateInstance<ProtoBDRepo>(s, dbPath));


            return builder.Build();
        }
    }
}
