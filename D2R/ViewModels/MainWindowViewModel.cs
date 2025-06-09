using D2R.Views.UserControls;
using System.ComponentModel;

namespace D2R.ViewModels
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        public MainWindowViewModel()
        {
            var loginVm = new LoginViewModel();
            loginVm.LoginSucceeded += OnLoginSucceeded; // thêm phương thức xử lí sự kiện khi đăng nhập thành công
            CurrentView = loginVm; // currentView đang chứa LoginViewModel => ContentControl.Content đang bind đến LoginViewModel
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
            CurrentView = new MenuView();
        }
    }
}