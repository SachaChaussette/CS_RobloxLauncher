using CS_RobloxLauncher.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CS_RobloxLauncher.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private Game selectedGame;

        public Game SelectedGame
        {
            get => selectedGame;
            set
            {
                selectedGame = value;
                OnPropertyChanged();
            }
        }

        public ICommand PlayCommand { get; }

        public GameViewModel()
        {
            SelectedGame = new Game
            {
                Name = "Blox Fruits",
                Thumbnail = "https://tr.rbxcdn.com/180DAY-a64f70da20fc1e80ee76fe5d49c1be0a/150/150/Image/Webp/noFilter",
                PlaceId = "2753915549"
            };

            PlayCommand = new RelayCommand(PlayGame);
        }
        public GameViewModel(string _name, string _thumbnail, string _id)
        {
            SelectedGame = new Game
            {
                Name = _name,
                Thumbnail = _thumbnail,
                PlaceId = _id
            };

            PlayCommand = new RelayCommand(PlayGame);
        }
        public GameViewModel(Game _game)
        {
            SelectedGame = _game;

            PlayCommand = new RelayCommand(PlayGame);
        }

        private void PlayGame(object _obj)
        {
            string _url = $"roblox://placeId={SelectedGame.PlaceId}";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _url,
                    UseShellExecute = true
                });
            }
            catch
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = $"https://www.roblox.com/games/{SelectedGame.PlaceId}",
                    UseShellExecute = true
                });
            }
        }
    }
}
