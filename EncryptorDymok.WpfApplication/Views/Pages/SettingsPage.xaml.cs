using EncryptorDymok.WpfApplication.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace EncryptorDymok.WpfApplication.Views.Pages;

/// <summary>
///     Interaction logic for SettingsPage.xaml
/// </summary>
public partial class SettingsPage : INavigableView<SettingsViewModel>
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }

    public SettingsViewModel ViewModel { get; }
}