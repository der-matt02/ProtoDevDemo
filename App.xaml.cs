using ProtoDevDemo.Repositories;
using System.Globalization;

namespace ProtoDevDemo
{
    public partial class App : Application
    {
        public static ProtoBDRepo ProtoBDRepo { get; private set; }
        public App(ProtoBDRepo repo)
        {
            InitializeComponent();
            // Establecer la cultura a "es-EC" (Ecuador)
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-EC");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-EC");

            MainPage = new AppShell();
            ProtoBDRepo = repo;
        }
    }
}