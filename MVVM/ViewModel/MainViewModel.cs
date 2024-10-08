using System;
using Wpf_Mvvm_Navigation.Services;
using Wpf_Mvvm_Navigation.Utilities;

namespace Wpf_Mvvm_Navigation.MVVM.ViewModel
{
    public class MainViewModel : Utilities.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateSettingsCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;

            NavigateHomeCommand = new RelayCommand(
                execute: o => Navigation.NavigateTo<HomeViewModel>(),
                canExecute: o => true
            );

            NavigateSettingsCommand = new RelayCommand(
                execute: o => Navigation.NavigateTo<SettingsViewModel>(),
                canExecute: o => true
            );
        }
    }
}
