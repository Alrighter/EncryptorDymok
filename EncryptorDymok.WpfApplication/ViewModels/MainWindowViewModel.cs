﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using EncryptorDymok.WpfApplication.Views.Pages;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace EncryptorDymok.WpfApplication.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private string _applicationTitle = string.Empty;

    private bool _isInitialized;

    [ObservableProperty] private ObservableCollection<INavigationControl> _navigationFooter = new();

    [ObservableProperty] private ObservableCollection<INavigationControl> _navigationItems = new();

    [ObservableProperty] private ObservableCollection<MenuItem> _trayMenuItems = new();

    public MainWindowViewModel(INavigationService navigationService)
    {
        if (!_isInitialized)
            InitializeViewModel();
    }

    private void InitializeViewModel()
    {
        ApplicationTitle = "Encryptor dymok";

        NavigationItems = new ObservableCollection<INavigationControl>
        {
            new NavigationItem
            {
                Content = "Encryptor",
                PageTag = "encryptor",
                Icon = SymbolRegular.LockClosed24,
                PageType = typeof(EncryptorPage)
            },
            new NavigationItem
            {
                Content = "Complex encryptor",
                PageTag = "hard_encryptor",
                Icon = SymbolRegular.LockMultiple24,
                PageType = typeof(HardEncryptorPage)
            }
        };

        NavigationFooter = new ObservableCollection<INavigationControl>
        {
            new NavigationItem
            {
                Content = "Settings",
                PageTag = "settings",
                Icon = SymbolRegular.Settings24,
                PageType = typeof(SettingsPage)
            }
        };

        TrayMenuItems = new ObservableCollection<MenuItem>
        {
            new()
            {
                Header = "Home",
                Tag = "tray_home"
            }
        };

        _isInitialized = true;
    }
}