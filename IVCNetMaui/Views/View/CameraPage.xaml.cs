using IVCNetMaui.Controls;
using IVCNetMaui.ViewModels.View;

namespace IVCNetMaui.Views.View;

public partial class CameraPage : ContentPage
{
	public CameraPage()
	{
		InitializeComponent();
        BuildGrid(1);
	}

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (BindingContext is CameraViewModel viewModel)
        {
            viewModel.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(viewModel.CameraCount))
                {
                    if (e.PropertyName == nameof(viewModel.CameraCount))
                        BuildGrid(viewModel.CameraCount);
                }
            };
        }
    }

    void BuildGrid(int rows)
    {
        if (BindingContext is CameraViewModel viewModel)
        {
            FlexibleGrid.Children.Clear();
            FlexibleGrid.RowDefinitions.Clear();
            for (int i = 0; i < rows; i++)
            {
                FlexibleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                var camera = viewModel.Cameras[i];
                FlexibleGrid.Children.Add(camera);
                Grid.SetRow(camera, i);
            }
        }

    }
}