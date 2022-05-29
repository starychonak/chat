using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ChatApp;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}