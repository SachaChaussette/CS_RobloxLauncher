using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_RobloxLauncher.Models;

namespace CS_RobloxLauncher
{
    public class GameManager
    {
        private static GameManager instance;

        Game selectedGame;

        public Game SelectedGame
        {
            get
            {
                return selectedGame;
            }
            set
            {
                selectedGame = value;
            }
        }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        private GameManager()
        {
            SelectedGame = new Game
            {
                Name = "Bee Swarm Simulator",
                Thumbnail = "https://tr.rbxcdn.com/180DAY-9d7481d5f4b40acde9feacd3c3212e9f/150/150/Image/Webp/noFilter",
                PlaceId = "1537690962"
            };
        }
    }
}
