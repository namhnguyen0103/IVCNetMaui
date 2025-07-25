namespace IVCNetMaui.Services.Dialog;

public class DialogService : IDialogService
{
    public Task ShowAlertAsync(string title, string message, string cancel)
    {
        return Application.Current!.MainPage!.DisplayAlert(title, message, cancel);
    }

    public Task<bool> ShowConfirmationAsync(string title, string message, string accept, string cancel)
    {
        return Application.Current!.MainPage!.DisplayAlert(title, message, accept, cancel);
    }
}