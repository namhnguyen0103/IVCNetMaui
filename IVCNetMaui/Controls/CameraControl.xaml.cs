using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using IVCNetMaui.Models;
using IVCNetMaui.Models.IoT;
using IVCNetMaui.ViewModels.View;

namespace IVCNetMaui.Controls;

public partial class CameraControl : ContentView
{
    public static readonly BindableProperty UnitsProperty = BindableProperty.Create(nameof(Units), typeof(List<Unit>), typeof(CameraControl), new List<Unit>(), propertyChanged:
	    (bindable, value, newValue) =>
	    {
		    
	    });
    
    public List<Unit> Units
    {
	    get => (List<Unit>)GetValue(UnitsProperty);
	    set => SetValue(UnitsProperty, value);
    }

    public List<Feed> Feeds => Units.Count > 0 && SelectedUnitIndex < Units.Count
	    ? new List<Feed>(Units[SelectedUnitIndex].Feeds) 
	    : new List<Feed>();

    private int _selectedUnitIndex = -1;
    public int SelectedUnitIndex
    {
	    get => _selectedUnitIndex;
	    set
	    {
		    if (_selectedUnitIndex != value)
		    {
			    _selectedUnitIndex = value;
			    SelectedFeedIndex = -1;
			    OnPropertyChanged();
			    OnPropertyChanged(nameof(FeedPickerEnabled));
			    OnPropertyChanged(nameof(Feeds));
		    }
	    }
    }


    private int _selectedFeedIndex = -1;

    public int SelectedFeedIndex
    {
	    get => _selectedFeedIndex;
	    set
	    {
		    if (_selectedFeedIndex != value)
		    {
			    _selectedFeedIndex = value;
			    OnPropertyChanged();
				ChangeContent();
		    }
	    }
    }
    public bool FeedPickerEnabled => SelectedUnitIndex > -1;
    
    public CameraControl()
    {
		InitializeComponent();
	}

    public void ChangeContent()
    {
	    if (SelectedUnitIndex > -1 && SelectedUnitIndex < Units.Count && SelectedFeedIndex > -1 &&
	        SelectedFeedIndex < Feeds.Count)
	    {
		    ContentBorder.Content = new MediaElement()
		    {
			    Source = MediaSource.FromFile("YCX-H264-640x360.mp4")
		    };
	    }
	    else
	    {
		    ContentBorder.Content = new Label()
		    {
			    Text = "Select a feed",
			    VerticalTextAlignment = TextAlignment.Center,
			    HorizontalTextAlignment = TextAlignment.Center,
			    TextColor = (Color)Application.Current.Resources["Gray700"],
		    };
	    }
    }
}