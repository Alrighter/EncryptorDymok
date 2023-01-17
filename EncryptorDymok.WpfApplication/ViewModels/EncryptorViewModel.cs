using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EncryptorDymok.WpfApplication.Services;
using TextCopy;
using Wpf.Ui.Common.Interfaces;

namespace EncryptorDymok.WpfApplication.ViewModels;

public partial class EncryptorViewModel : ObservableObject, INavigationAware
{
    [ObservableProperty] private bool _isEncrypt;

    [ObservableProperty] private string? _key;

    [ObservableProperty] private string? _result;

    [ObservableProperty] private string? _text;

    public void OnNavigatedTo()
    {
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void Encrypt()
    {
        if (Text is null)
        {
            Result = "Text is null";
            return;
        }

        if (IsEncrypt)
            Result = EncryptionService.SimpleDecrypt(_text);
        else
            Result = EncryptionService.SimpleEncrypt(_text);

        Text = string.Empty;
    }
    [RelayCommand]
    private void HardEncrypt()
    {
        if (Text is null)
        {
            Result = "Text is null";
            return;
        }

        if (Key is null)
        {
            Result = "Key is null";
            return;
        }

        if (IsEncrypt)
            Result = EncryptionService.DecryptText(_text, _key);
        else
            Result = EncryptionService.EncryptText(_text, _key);

        Text = string.Empty;
    }

    [RelayCommand]
    private void PasteHard()
    {
        Text = ClipboardService.GetText();
        HardEncrypt();
    }

    [RelayCommand]
    private void Copy()
    {
        ClipboardService.SetText(_result);
        Text = string.Empty;
        Result = string.Empty;
    }

    [RelayCommand]
    private void Paste()
    {
        Text = ClipboardService.GetText();
        Encrypt();
    }
}