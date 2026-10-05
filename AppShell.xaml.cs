using CalculateurAge.Views;

namespace CalculateurAge;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Enregistrement explicite de la route pour la navigation Shell
        Routing.RegisterRoute(nameof(ResultatPage), typeof(ResultatPage));
    }
}
