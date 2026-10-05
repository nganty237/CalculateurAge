namespace CalculateurAge.Views;

/// <summary>
/// Page d'affichage du résultat recevant les paramètres 'nom' et 'age' via QueryProperty.
/// </summary>
[QueryProperty(nameof(Nom), "nom")]
[QueryProperty(nameof(Age), "age")]
public partial class ResultatPage : ContentPage
{
    public string Nom { get; set; } = string.Empty;
    public string Age { get; set; } = string.Empty;

    public ResultatPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        lblMessage.Text = $"{Nom}, vous avez {Age} ans";
    }

    private async void OnRetourClicked(object? sender, EventArgs e)
    {
        // Retour à la page précédente dans la pile de navigation Shell
        await Shell.Current.GoToAsync("..");
    }
}
