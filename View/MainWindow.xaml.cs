using System.Windows;
using Wpf_Mvvm_Navigation.MVVM.ViewModel;
using Wpf_Mvvm_Navigation.Utilities;
using Wpf_Mvvm_Navigation.Services;

namespace Wpf_Mvvm_Navigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // ViewModel fabrikası oluştur
            Func<Type, ViewModel> viewModelFactory = (type) =>
            {
                if (type == typeof(HomeViewModel))
                {
                    return new HomeViewModel(); // HomeViewModel örneği
                }
                else if (type == typeof(SettingsViewModel))
                {
                    return new SettingsViewModel(); // SettingsViewModel örneği
                }
                return null; // Geçersiz tür için null döner
            };

            // MainViewModel'i oluştur ve DataContext olarak ayarla
            DataContext = new MainViewModel(new NavigationService(viewModelFactory));
        }
    }
}
