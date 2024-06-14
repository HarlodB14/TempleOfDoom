using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempleOfDoomModel
{
    public class Game
    {
        public List<Room> rooms { get; private set; }

        public String jsonFilePath { get; private set; }
        public Player player { get; set; }
        public bool Quit { get; private set; }

        public Game(string jsonFilePath)
        {
            Quit = false;
            rooms = new List<Room>();
            this.jsonFilePath = jsonFilePath;
        }

        public bool CheckIfPlayerWon()
        {
            int amountOfStones = player._Items.Count(s => s.Type == "sankara stone");
            bool hasWon = false;

            if (amountOfStones == 5)
            {
                hasWon = true;
                return hasWon;
            }
            return hasWon;
        }

        public bool CheckIfPlayerLost()
        {
            int lives = player.GetLives();
            bool hasLost = false;
            if (lives == 0)
            {
                hasLost = true;
            }
            return hasLost;
        }


    }
}
