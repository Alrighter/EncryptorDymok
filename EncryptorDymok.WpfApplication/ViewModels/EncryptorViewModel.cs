using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EncryptorDymok.WpfApplication.Services;
using Wpf.Ui.Common.Interfaces;

namespace EncryptorDymok.WpfApplication.ViewModels;

public partial class EncryptorViewModel : ObservableObject, INavigationAware
{
    [ObservableProperty] private bool _isEncrypt;

    [ObservableProperty] private string? _key;

    [ObservableProperty] private string? _result;

    [ObservableProperty] private string? _text;

    public EncryptorViewModel()
    {
        
    }

    public void OnNavigatedTo()
    {
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void Encrypt()
    {
        _result = _isEncrypt ? Convert.ToBase64String(EncryptorService.EncryptStringToBytes_Aes(_text, _key)) : EncryptorService.DecryptStringFromBytes_Aes(Convert.FromBase64String(_text), _key);
    }
}