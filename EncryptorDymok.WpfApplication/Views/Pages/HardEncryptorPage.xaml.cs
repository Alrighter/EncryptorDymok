using EncryptorDymok.WpfApplication.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace EncryptorDymok.WpfApplication.Views.Pages;

/// <summary>
///     Логика взаимодействия для HardEncryptorPage.xaml
/// </summary>
public partial class HardEncryptorPage : INavigableView<EncryptorViewModel>
{
    public HardEncryptorPage(EncryptorViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }

    public EncryptorViewModel ViewModel { get; }
}