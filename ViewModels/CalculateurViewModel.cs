namespace CalculateurAge.ViewModels;

/// <summary>
/// ViewModel principal gérant l'état et la logique de calcul d'âge de l'application.
/// </summary>
public class CalculateurViewModel : BaseViewModel
{
    private string _nom = string.Empty;
    private DateTime _dateNaissance = DateTime.Today.AddYears(-20);
    private string _resultat = string.Empty;
    private string _statut = string.Empty;
    private string _joursAvantAnniversaire = string.Empty;
    private bool _resultatVisible;

    /// <summary>
    /// Nom saisi par l'utilisateur.
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
    /// Résultat principal affiché après le calcul (ex : "Alice, vous avez 25 ans").
    /// </summary>
    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }

    /// <summary>
    /// Statut de majorité : "Majeur" ou "Mineur".
    /// </summary>
    public string Statut
    {
        get => _statut;
        set => SetField(ref _statut, value);
    }

    /// <summary>
    /// Nombre de jours restants avant le prochain anniversaire.
    /// </summary>
    public string JoursAvantAnniversaire
    {
        get => _joursAvantAnniversaire;
        set => SetField(ref _joursAvantAnniversaire, value);
    }

    /// <summary>
    /// Contrôle la visibilité du bloc de résultats.
    /// </summary>
    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }

    /// <summary>
    /// Commande de calcul de l'âge, désactivée si le champ Nom est vide.
    /// </summary>
    public RelayCommand CalculerCommand { get; }

    /// <summary>
    /// Commande de remise à zéro de tous les champs.
    /// </summary>
    public RelayCommand EffacerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(Calculer, () => !string.IsNullOrWhiteSpace(Nom));
        EffacerCommand  = new RelayCommand(Effacer);
    }

    /// <summary>
    /// Calcule l'âge, le statut et les jours avant le prochain anniversaire.
    /// Aucune référence à des contrôles UI.
    /// </summary>
    private void Calculer()
    {
        int age = DateTime.Today.Year - DateNaissance.Year;

        if (DateNaissance.Date > DateTime.Today.AddYears(-age))
        {
            age--;
        }

        // Prochain anniversaire
        DateTime prochainAnniversaire = DateNaissance.AddYears(
            DateTime.Today.Year - DateNaissance.Year);

        if (prochainAnniversaire < DateTime.Today)
        {
            prochainAnniversaire = prochainAnniversaire.AddYears(1);
        }

        int joursRestants = (prochainAnniversaire - DateTime.Today).Days;

        Resultat               = $"{Nom}, vous avez {age} ans";
        Statut                 = age >= 18 ? "Majeur" : "Mineur";
        JoursAvantAnniversaire = joursRestants == 0
            ? "Bon anniversaire !"
            : $"Prochain anniversaire dans {joursRestants} jour(s)";
        ResultatVisible = true;
    }

    /// <summary>
    /// Remet toutes les propriétés à leur valeur initiale.
    /// </summary>
    private void Effacer()
    {
        Nom                    = string.Empty;
        DateNaissance          = DateTime.Today.AddYears(-20);
        Resultat               = string.Empty;
        Statut                 = string.Empty;
        JoursAvantAnniversaire = string.Empty;
        ResultatVisible        = false;
    }
}
