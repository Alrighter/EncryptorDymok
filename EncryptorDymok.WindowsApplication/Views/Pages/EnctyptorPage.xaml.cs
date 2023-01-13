using EncryptorDymok.WindowsApplication.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace EncryptorDymok.WindowsApplication.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для EnctyptorPage.xaml
    /// </summary>
    public partial class EnctyptorPage : INavigableView<EncryptorViewModel>
    {
        public EnctyptorPage(EncryptorViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
        
        public EncryptorViewModel ViewModel { get; }
    }
}
