using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfApp0.StartUpHelpers;
using WpfLibrary;

namespace WpfApp0
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; } // il ? serve per indicare un potenziale contenuto nullo

        public App() {
            AppHost = Host.CreateDefaultBuilder().
                ConfigureServices((hostContext, services) =>
                {
                    // si vuole creare una sola istanza della finestra principale
                    services.AddSingleton<MainWindow>();
                    services.AddFormFactory<ChildForm>();
                    services.AddTransient<IDataAccess, DataAccess>();
                })
                .Build();
        }

        // metodo protected perché accessibile o estendibile solo dalle classi che derivano da App
        // override perché si estende la funzione di partenza
        // async perché consente di eseguire le funzionalità senza bloccare il flusso principale dell'esecuzione
        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync(); // funzione sincrona per aspettare le operazioni necessarie, operazione bloccante

            var startUpForm = AppHost.Services.GetRequiredService<MainWindow>();
            startUpForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
