using CS_RobloxLauncher.Models;
using CS_RobloxLauncher.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CS_RobloxLauncher.ViewModels
{
    public class ChartsPageViewModel : ViewModelBase
    {
        public Action OnSelectGame { get; set; } = null;

        public ICommand SelectGame { get; set; }

        public ObservableCollection<Game> AllGames { get; set; } = new ObservableCollection<Game>();

        public ChartsPageViewModel()
        {
            LoadGamesAsync();

            SelectGame = new RelayCommand(OnSelectGameMethod);
        }

        private async Task LoadGamesAsync()
        {
            Games _response = await DataAPI.GetDataFromAPI<Games>(BaseURL.GET_ROBLOX_API);

            foreach (KeyValuePair<string, object[]> _pair in _response.AllGames)
            {
                string _placeId = _pair.Key;
                object[] _values = _pair.Value;

                Game _game = new Game
                {
                    PlaceId     = _placeId,
                    Name        = _values[0].ToString(),
                    Players     = int.Parse(_values[1].ToString()),
                    Thumbnail   = _values[2].ToString()
                };

                // TODO SUP
                if (AllGames.Count > 100) return;

                AllGames.Add(_game);
            }
        }

        void OnSelectGameMethod(object sender)
        {
            Game _game = (Game)sender;

            GameManager.Instance.SelectedGame = _game;

            OnSelectGame?.Invoke();
        }
    }
}
