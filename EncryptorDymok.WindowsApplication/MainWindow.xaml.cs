using System;
using System.Windows.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace EncryptorDymok.WindowsApplication;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : INavigationWindow
{
    public Frame GetFrame()
    {
        throw new NotImplementedException();
    }

    public INavigation GetNavigation()
    {
        throw new NotImplementedException();
    }

    public bool Navigate(Type pageType)
    {
        throw new NotImplementedException();
    }

    public void SetPageService(IPageService pageService)
    {
        throw new NotImplementedException();
    }

    public void ShowWindow()
    {
        throw new NotImplementedException();
    }

    public void CloseWindow()
    {
        throw new NotImplementedException();
    }
}