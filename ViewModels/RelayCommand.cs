using System.Windows.Input;

namespace CalculateurAge.ViewModels;

/// <summary>
/// Implémentation standard de ICommand pour relier les actions de l'interface utilisateur aux méthodes du ViewModel.
/// </summary>
public class RelayCommand : ICommand
{
    private readonly Action _executer;
    private readonly Func<bool>? _peutExecuter;

    public RelayCommand(Action executer, Func<bool>? peutExecuter = null)
    {
        _executer = executer ?? throw new ArgumentNullException(nameof(executer));
        _peutExecuter = peutExecuter;
    }

    /// <summary>
    /// Vérifie si la commande peut être exécutée (permet d'activer/désactiver le bouton lié).
    /// </summary>
    public bool CanExecute(object? parameter)
    {
        return _peutExecuter?.Invoke() ?? true;
    }

    /// <summary>
    /// Exécute l'action associée à la commande.
    /// </summary>
    public void Execute(object? parameter)
    {
        _executer();
    }

    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Force la réévaluation de la condition d'exécution de la commande (met à jour l'état activé/désactivé des boutons liés).
    /// </summary>
    public void Rafraichir()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
