using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace ContentDialogCanExecuteRepro;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
    }

    private async void myButton_Click(object sender, RoutedEventArgs e)
    {
        UnexecutableCommand command = new();
        ContentDialog dialog = new() 
        {
            XamlRoot = Content.XamlRoot,
            PrimaryButtonText = "Primary",
            PrimaryButtonCommand = command
        };

        command.NotifyCanExecuteChanged();
        await dialog.ShowAsync();
    }
}
