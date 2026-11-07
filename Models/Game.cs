using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobloxLauncher.Models
{
    public struct Games
    {
        [JsonProperty("success")]
        public bool                         Success     { get; set; }
        [JsonProperty("game_count")]
        public int                          GameCount   { get; set; }
        [JsonProperty("games")]
        public Dictionary<string, object[]> AllGames    { get; set; }
    }

    public class Game
    {
        public string   PlaceId     { get; set; }
        public string   Name        { get; set; }
        public int      Players     { get; set; }
        public string   Thumbnail   { get; set; }


    }
}
