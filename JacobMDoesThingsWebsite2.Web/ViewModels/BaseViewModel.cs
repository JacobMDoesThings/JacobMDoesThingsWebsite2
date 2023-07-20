namespace JacobMDoesThingsWebsite2.Web.ViewModels;

/// <summary>
/// Base viewmodel.
/// </summary>
public abstract class BaseViewModel : INotifyPropertyChanged
{
    /// <inheritdoc/>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// PropertyChanged event to notify UI of changes.
    /// </summary>
    protected virtual void OnPropertyChanged() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
}
