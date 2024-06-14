using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using TempleOfDoomModel;

namespace TempleOfDoomView
{
    public class GameView
    {
        private readonly Game _game;
        private readonly RoomView _roomView; // Assuming you have a RoomView class to display the room
        private readonly Player _player;

        public GameView(Game game)
        {
            _game = game;
            _player = game.player;
            _roomView = new RoomView(_player.CurrentRoom, _game.player); // Initialize with current room and player
        }

        public void Display()
        {
            Console.Clear();
            DisplayHeader();
            _roomView.Display(); // Delegate the display of the room to RoomView
            DisplayFooter();
        }

        private void DisplayHeader()
        {
            Console.WriteLine("Welcome to The Temple of Doom!");
            Console.WriteLine($"Current level: {_game.jsonFilePath}");
            Console.WriteLine(new string('-', Console.WindowWidth)); // Print a separator line
        }

        private void DisplayFooter()
        {
            Console.WriteLine(new string('-', Console.WindowWidth)); // Print a separator line
            Console.WriteLine($"Lives: {_player._lives}");
            Console.WriteLine($"Sankara Stone's: {_player._Items.Count(s => s.Type == "sankara stone")}");
            Console.WriteLine(new string('-', Console.WindowWidth)); // Print a separator line
            Console.WriteLine("A game for the course Code Development (23/24) by Thom van der Looij and Harlod Bombala.");
        }
    }
}

