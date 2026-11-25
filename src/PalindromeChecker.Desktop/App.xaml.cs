using Microsoft.Extensions.DependencyInjection;
using PalindromeChecker.Core;
using System.Windows;

namespace PalindromeChecker.Desktop;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private ServiceProvider? _serviceProvider;
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();

        // Register dependencies
        services.AddSingleton<IPalindromeService, PalindromeService>();
        services.AddTransient<MainWindow>();

        _serviceProvider = services.BuildServiceProvider();

        // The container creates MainWindow and injects its dependencies
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
    protected override void OnExit(ExitEventArgs e)
    {
        _serviceProvider?.Dispose();
        base.OnExit(e);
    }
}

