using D2R.Views;
using System.ComponentModel;

namespace D2R.ViewModels
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        public MainWindowViewModel()
        {
            var loginVm = new LoginViewModel();
            loginVm.LoginSucceeded += OnLoginSucceeded;
            CurrentView = loginVm;
        }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OnLoginSucceeded()
        {
            CurrentView = new MainLayout();
        }
    }
}