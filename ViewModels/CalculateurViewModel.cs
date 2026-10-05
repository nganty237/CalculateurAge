namespace CalculateurAge.ViewModels;

/// <summary>
/// ViewModel principal gérant l'état et la logique de calcul d'âge de l'application.
/// </summary>
public class CalculateurViewModel : BaseViewModel
{
    private string _nom = string.Empty;
    private DateTime _dateNaissance = DateTime.Today.AddYears(-20);
    private string _resultat = string.Empty;
    private bool _resultatVisible;

    /// <summary>
    /// Nom saisi par l'utilisateur.
    /// La modification de cette propriété réévalue la condition d'exécution de CalculerCommand.
    /// </summary>
    public string Nom
    {
        get => _nom;
        set
        {
            if (SetField(ref _nom, value))
            {
                CalculerCommand.Rafraichir();
            }
        }
    }

    /// <summary>
    /// Date de naissance sélectionnée.
    /// </summary>
    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set => SetField(ref _dateNaissance, value);
    }

    /// <summary>
    /// Message de résultat affiché à l'utilisateur.
    /// </summary>
    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }

    /// <summary>
    /// Indique si le label de résultat doit être visible.
    /// </summary>
    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }

    /// <summary>
    /// Commande associée au bouton de calcul.
    /// </summary>
    public RelayCommand CalculerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(
            Calculer,
            () => !string.IsNullOrWhiteSpace(Nom));
    }

    /// <summary>
    /// Logique métier de calcul de l'âge sans aucune dépendance visuelle.
    /// </summary>
    private void Calculer()
    {
        int age = DateTime.Today.Year - DateNaissance.Year;

        if (DateNaissance.Date > DateTime.Today.AddYears(-age))
        {
            age--;
        }

        Resultat = $"{Nom}, vous avez {age} ans";
        ResultatVisible = true;
    }
}
