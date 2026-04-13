using CS_RobloxLauncher.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CS_RobloxLauncher.ViewModels
{
    public class ChartsPageViewModel : ViewModelBase
    {
        public ObservableCollection<Game> AllGames { get; set; } = new ObservableCollection<Game>();

        public ChartsPageViewModel()
        {
            LoadGamesAsync();

           
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
                    PlaceId = _placeId,
                    Name = _values[0].ToString(),
                    Players = int.Parse(_values[1].ToString()),
                    Thumbnail = _values[2].ToString()
                };

                AllGames.Add(_game);
            }
        }
    }
}
