using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalculateurAge.ViewModels;

/// <summary>
/// Classe de base pour les ViewModels implémentant INotifyPropertyChanged.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Événement déclenché lors du changement d'une propriété pour mettre à jour l'interface via le Data Binding.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Notifie les abonnés du changement d'une propriété.
    /// </summary>
    /// <param name="nom">Nom de la propriété modifiée (renseigné automatiquement via CallerMemberName).</param>
    protected void OnPropertyChanged([CallerMemberName] string? nom = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nom));
    }

    /// <summary>
    /// Affecte une nouvelle valeur à un champ et déclenche la notification si la valeur a changé.
    /// </summary>
    /// <typeparam name="T">Type de la propriété.</typeparam>
    /// <param name="champ">Référence au champ privé.</param>
    /// <param name="valeur">Nouvelle valeur à assigner.</param>
    /// <param name="nom">Nom de la propriété appelante.</param>
    /// <returns>True si la valeur a été modifiée, sinon False.</returns>
    protected bool SetField<T>(ref T champ, T valeur, [CallerMemberName] string? nom = null)
    {
        if (EqualityComparer<T>.Default.Equals(champ, valeur))
        {
            return false;
        }

        champ = valeur;
        OnPropertyChanged(nom);
        return true;
    }
}
