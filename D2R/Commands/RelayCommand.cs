using System.Windows.Input;

namespace D2R.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute; // Logic chính
        private readonly Predicate<object>? _canExecute; // điều kiện thực thi

        public RelayCommand(Action<object> execute, Predicate<object>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter!);
        public void Execute(object? parameter) => _execute(parameter!);
    }
}