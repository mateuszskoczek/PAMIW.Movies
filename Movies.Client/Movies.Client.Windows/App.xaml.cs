using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Movies.Client.Services.Movies;
using Movies.Client.Windows.ViewModels.Views;
using Movies.Client.Windows.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Movies.Client.Windows
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            // Config build
            IConfigurationSource apiConfig = new JsonConfigurationSource()
            {
                Path = "Config/api.json"
            };

            IConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.Add(apiConfig);

            IConfiguration config = configBuilder.Build();


            // Services build
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton(config);
            services.AddSingleton<MoviesConfiguration>();

            services.AddSingleton<IMoviesService, MoviesService>();

            services.AddSingleton<MainWindowVM>();

            services.AddTransient<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
