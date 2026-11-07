using RobloxLauncher.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RobloxLauncher.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public Game SelectedGame => GameManager.Instance.SelectedGame;

        public Action OnExitGame { get; set; } = null;

        public ICommand PlayCommand { get; }
        public ICommand OnExitCommand { get; }

        public GameViewModel()
        {
            //SelectedGame = GameManager.Instance.SelectedGame;

            PlayCommand = new RelayCommand(PlayGame);
            OnExitCommand = new RelayCommand(OnExit);
        }
        public GameViewModel(string _name, string _thumbnail, string _id)
        {
            //SelectedGame = new Game
            //{
            //    Name = _name,
            //    Thumbnail = _thumbnail,
            //    PlaceId = _id
            //};

            PlayCommand = new RelayCommand(PlayGame);
        }
        public GameViewModel(Game _game)
        {
            //SelectedGame = _game;

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

        void OnExit(object? _obj)
        {
            OnExitGame?.Invoke();
        }

        private bool _isOptionsOpen;

        public bool IsOptionsOpen
        {
            get => _isOptionsOpen;
            set
            {
                _isOptionsOpen = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToggleOptionsCommand => new RelayCommand(_c =>
        {
            IsOptionsOpen = !IsOptionsOpen;
        });

        public ICommand InviteFriendsCommand => new RelayCommand(_c =>
        {
            MessageBox.Show("Tu n'as pas d'ami...");
        });

        public ICommand CopyLinkCommand => new RelayCommand(_c =>
        {
            MessageBox.Show("Lien copié dans la corbeille.");
        });

        public ICommand ReportCommand => new RelayCommand(_c =>
        {
            MessageBox.Show("Tu t'es Report avec succee!");
        });
    }
}
