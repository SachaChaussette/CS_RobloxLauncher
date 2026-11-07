using RobloxLauncher.Models;
using RobloxLauncher.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RobloxLauncher.ViewModels
{
    public class FilterItem
    {
        public string Text { get; set; }
    }

    public class ChartsPageViewModel : ViewModelBase
    {
        private Visibility visibilityError = Visibility.Collapsed;
        public Visibility VisibilityError
        {
            get => visibilityError;
            set
            {
                visibilityError = value;
                OnPropertyChanged(nameof(VisibilityError));
            }
        }
        public Action OnSelectGame { get; set; } = null;

        public ICommand SelectGame { get; set; }
        public ICommand HideErrorCommand { get; set; }
        public ICommand ShowErrorCommand { get; set; }

        public ObservableCollection<Game> AllGames { get; set; } = new ObservableCollection<Game>();

        public ChartsPageViewModel()
        {
            SelectGame = new RelayCommand(OnSelectGameMethod);
            ShowErrorCommand = new RelayCommand(OnShowError);
            HideErrorCommand = new RelayCommand(OnHideError);
        }


        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public async Task LoadGamesAsync()
        {
            if (IsLoading)
                return;

            IsLoading = true;

            try
            {
                // 1. Récupération asynchrone depuis l'API
                Games _response = await DataAPI.GetDataFromAPI<Games>(BaseURL.GET_ROBLOX_API);

                if (_response.AllGames == null) return;

                // 2. Transformation des données hors du thread UI
                List<Game> _games = await Task.Run(() =>
                {
                    return _response.AllGames.Take(1000000).Select(_pair =>
                        {
                            object[] _values = _pair.Value;

                            return new Game
                            {
                                PlaceId = _pair.Key,
                                Name = _values[0]?.ToString() ?? "",
                                Players = int.TryParse(_values[1]?.ToString(), out int _players) ? _players : 0,
                                Thumbnail = _values[2]?.ToString() ?? ""
                            };
                        })
                        .ToList();
                });

                // 3. Ajout progressif des jeux dans l'interface
                AllGames.Clear();

                const int batchSize = 20;

                AllGames = new ObservableCollection<Game>(_games);
                OnPropertyChanged(nameof(AllGames));
            }
            catch (Exception _ex)
            {
                MessageBox.Show($"Erreur de chargement : {_ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }


        void OnSelectGameMethod(object sender)
        {
            Game _game = (Game)sender;

            GameManager.Instance.SelectedGame = _game;

            OnSelectGame?.Invoke();
        }

        void OnShowError(object? sender)
        {
            VisibilityError = Visibility.Visible;
        }

        void OnHideError(object? sender)
        {
            VisibilityError = Visibility.Collapsed;
        }
    }
}
