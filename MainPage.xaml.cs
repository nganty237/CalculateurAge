using CalculateurAge.ViewModels;

namespace CalculateurAge;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // Définition du contexte de liaison de données pour la vue
        BindingContext = new CalculateurViewModel();
    }
}
