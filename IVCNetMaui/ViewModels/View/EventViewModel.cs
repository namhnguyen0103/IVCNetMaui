namespace IVCNetMaui.ViewModels.View;
using CommunityToolkit.Mvvm;
using System.ComponentModel;

public class EventViewModel : INotifyPropertyChanged
{
	public EventViewModel()
	{
	}

    public event PropertyChangedEventHandler? PropertyChanged;
}