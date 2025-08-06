using IVCNetMaui.Controls;
using IVCNetMaui.ViewModels.View;

namespace IVCNetMaui.Views.View;

public partial class CameraPage : ContentPage
{
	public CameraPage(CameraViewModel vm)
	{
        BindingContext = vm;
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
                    BuildGrid(viewModel.CameraCount);
                }
            };
        }
    }

    void BuildGrid(int cameras)
    {
        if (BindingContext is CameraViewModel viewModel)
        {
            FlexibleGrid.Children.Clear();
            FlexibleGrid.RowDefinitions.Clear();
            FlexibleGrid.ColumnDefinitions.Clear();
            if (cameras <= 2)
            {
                for (int i = 0; i < cameras; i++)
                {
                    FlexibleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    var camera = new CameraControl(viewModel.Cameras[i]);
                    FlexibleGrid.Children.Add(camera);
                    Grid.SetRow(camera, i);
                }
            } else if (cameras <= 4)
            {
                FlexibleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                FlexibleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                FlexibleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                FlexibleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                for (int i = 0; i < cameras; i++)
                {
                    var camera = new CameraControl(viewModel.Cameras[i]);
                    FlexibleGrid.Children.Add(camera);
                    if (i < 2)
                    {
                        Grid.SetRow(camera, 0);
                        Grid.SetColumn(camera, i);
                    }
                    else
                    {
                        Grid.SetRow(camera, 1);
                        Grid.SetColumn(camera, i - 2);
                    }

                }
            }
            else if (cameras <= 6)
            {
                FlexibleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                FlexibleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                FlexibleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                FlexibleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                FlexibleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                FlexibleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                for (int i = 0; i < cameras; i++)
                {
                    var camera = new CameraControl(viewModel.Cameras[i]);
                    FlexibleGrid.Children.Add(camera);
                    if (i < 2)
                    {
                        Grid.SetRow(camera, 0);
                        Grid.SetColumn(camera, i);
                    }
                    else if (i < 4)
                    {
                        Grid.SetRow(camera, 1);
                        Grid.SetColumn(camera, i - 2);
                    }
                    else
                    {
                        Grid.SetRow(camera, 2);
                        Grid.SetColumn(camera, i - 4);
                    }

                }
            }

            
            
            // FlexibleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            // var camera = new CameraControl(viewModel.Cameras.Last());
            // FlexibleGrid.Children.Add(camera);
            // Grid.SetRow(camera, rows - 1);
        }
    
    }
}