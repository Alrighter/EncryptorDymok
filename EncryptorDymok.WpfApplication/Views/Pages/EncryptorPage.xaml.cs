using EncryptorDymok.WpfApplication.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace EncryptorDymok.WpfApplication.Views.Pages;

/// <summary>
///     Логика взаимодействия для EncryptorPage.xaml
/// </summary>
public partial class EncryptorPage : INavigableView<EncryptorViewModel>
{
    public EncryptorPage(EncryptorViewModel viewModel)
    {
        InitializeComponent();
        
        ViewModel = viewModel;
    }

    public EncryptorViewModel ViewModel { get; }
}