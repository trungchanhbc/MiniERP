using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Management;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace MiniERP.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public string SecrectKey = "a973baad1982333ee84d0f7afd636a4869dfe60de33631ebf2cc50501364d028" +
                                   "f7be9d78eddea7e0190375644d7bacffe1e25d2d4b38aee30ca3a682f0d76b84";
        public static bool RegistrationVerified;

        public static ObservableCollection<string> LanguageList { get; set; }

        public BaseViewModel()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            }
            catch
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public static class LanguageManager
    {
        public static void SetLanguageDictionary(ELanguage lang)
        {
            ResourceDictionary Dict = new ResourceDictionary();
            switch(lang)
            {
                case ELanguage.English:
                    Dict.Source = new Uri("../ResourceXAML/MainResource-EN.xaml", UriKind.Relative);
                    break;
                case ELanguage.Vietnamese:
                    Dict.Source = new Uri("../ResourceXAML/MainResource-VN.xaml", UriKind.Relative);
                    break;
                case ELanguage.Francais:
                    Dict.Source = new Uri("../ResourceXAML/MainResource-FR.xaml", UriKind.Relative);
                    break;
                default:
                    Dict.Source = new Uri("../ResourceXAML/MainResource-EN.xaml", UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(Dict);
        }
    }
    public enum ELanguage 
        {
            English,
            Vietnamese,
            Francais
        }
}
