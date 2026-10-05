using CalculateurAge.Views;

namespace CalculateurAge;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gestionnaire de clic pour le calcul de l'âge et la navigation.
    /// </summary>
    private async void OnCalculerClicked(object? sender, EventArgs e)
    {
        // Validation : le nom ne doit pas être vide
        if (string.IsNullOrWhiteSpace(entryNom.Text))
        {
            await DisplayAlert("Erreur", "Entrez un nom", "OK");
            return;
        }

        DateTime dateNaissance = pickerDate.Date ?? DateTime.Today;
        int age = DateTime.Today.Year - dateNaissance.Year;

        // Ajustement si l'anniversaire n'a pas encore eu lieu cette année
        if (dateNaissance.Date > DateTime.Today.AddYears(-age))
        {
            age--;
        }

        // Navigation vers la page de résultat avec transmission des paramètres via l'URL
        await Shell.Current.GoToAsync($"{nameof(ResultatPage)}?nom={entryNom.Text}&age={age}");
    }
}
