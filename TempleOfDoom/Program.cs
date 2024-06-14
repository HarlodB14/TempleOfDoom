using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TempleOfDoomController;
using TempleOfDoomData;
using TempleOfDoomModel;
using TempleOfDoomView;
using TempleOfDoomData.Factories;
using TempleOfDoomController;

namespace TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string filePath = @"./JSON/TempleOfDoom"; // Example path without extension

            // Determine the type of reader strategy based on the file extension
            ILevelDataReader levelDataReader;
            if (File.Exists($"{filePath}.json"))
            {
                filePath += ".json";
                levelDataReader = new JsonLevelDataReader();
            }
            else if (File.Exists($"{filePath}.xml"))
            {
                filePath += ".xml";
                levelDataReader = new XmlLevelDataReader();
            }
            else
            {
                Console.WriteLine("No level file found.");
                return;
            }

            // Read the JSON file
            string json = File.ReadAllText(filePath);

            // Create the necessary factories
            var itemFactory = new ItemFactory();
            var roomFactory = new RoomFactory(itemFactory);
            var doorFactory = new DoorFactory();
            var connectionFactory = new ConnectionFactory(doorFactory);

            // Instantiate GameFileReader with the created factories
            GameFileReader fileReader = new GameFileReader(levelDataReader, roomFactory, connectionFactory);

            // Read the game data and create the game object
            Game game = fileReader.ReadGame(filePath);

            IOController ioController = new IOController(game);
            while (!game.Quit)
            {
                GameView view = new GameView(game);
                view.Display();
                ioController.ProcessInput();
                if (game.CheckIfPlayerWon())
                {
                    view.Display();
                    Console.WriteLine("The great Archeologist has done it!!! .... You have found all the stones!!!!");
                    break;
                }

                if (game.CheckIfPlayerLost())
                {
                    view.Display();
                    Console.WriteLine("NOOO INDYYYY YOUR DEADDD!!!! You have lost all your lives.");
                    break;
                }
            }



        }
    }
}
