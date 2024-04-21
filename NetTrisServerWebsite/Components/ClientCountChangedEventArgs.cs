namespace BlazorApp2.Components.Pages;

public class ClientCountChangedEventArgs(int newCount) : EventArgs
{
    public int NewCount { get; set; } = newCount;
}