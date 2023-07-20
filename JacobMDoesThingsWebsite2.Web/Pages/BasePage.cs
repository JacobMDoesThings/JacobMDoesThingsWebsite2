namespace JacobMDoesThingsWebsite2.Web.Pages;

/// <summary>
/// Base class for pages bound to a viewmodel.
/// </summary>
/// <typeparam name="T">View model type.</typeparam>
public class BasePage<T> : ComponentBase
    where T : INotifyPropertyChanged
{
    /// <summary>
    /// Gets or sets refrence to the viewmodel.
    /// </summary>
    [Inject]
    protected T? VM { get; set; }

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        if (VM is not null)
        {
            VM.PropertyChanged += (s, e) => InvokeAsync(StateHasChanged);
        }
    }
}