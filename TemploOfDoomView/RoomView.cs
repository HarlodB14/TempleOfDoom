using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TempleOfDoomModel;
using TempleOfDoomModel.Doors;
using TempleOfDoomModel.Doors.Decorators;
using TempleOfDoomModel.Items;
using TempleOfDoomView.ViewModels;

namespace TempleOfDoomView
{
    public class RoomView
    {
        private readonly Room _room;
        private readonly Player _player;
        private ConsoleText[,] grid;

        public RoomView(Room room, Player player)
        {
            Console.OutputEncoding = Encoding.UTF8;
            _room = room;
            _player = player;
            grid = new ConsoleText[_room.Width, _room.Height];
        }

        public void Display()
        {
            // Initialize grid with walls and empty spaces
            InitializeGrid();

            // Add items to grid
            foreach (var item in _room.Items)
            {
                var symbol = GetItemSymbol(item);
                grid[item.Position.xPos, item.Position.yPos] = symbol;
            }

            // Add doors to grid
            AddDoorsToGrid();

            // Add player to grid
            var playerSymbol = new ConsoleText(_player.Position.Equals(_player.StartPosition) ? "X" : "x", ConsoleColor.White);
            grid[_player.Position.xPos, _player.Position.yPos] = playerSymbol;

            // Print grid with adjusted spacing
            for (int y = 0; y < _room.Height; y++)
            {
                PrintLine(y); // Print each line of the grid
            }
        }

        private void PrintLine(int y)
        {
            for (int x = 0; x < _room.Width; x++)
            {
                var consoleText = grid[x, y];
                Console.ForegroundColor = consoleText.ForegroundColor;
                Console.BackgroundColor = consoleText.BackgroundColor;
                Console.Write(consoleText.Text + " "); // Add space after each character for width adjustment
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        private void AddDoorsToGrid()
        {
            foreach (var kvp in _room._connections)
            {
                var symbol = GetDoorSymbol(kvp.Value);

                int x = 0, y = 0;
                switch (kvp.Key)
                {
                    case "North":
                        x = _room.Width / 2;
                        y = 0;
                        break;
                    case "South":
                        x = _room.Width / 2;
                        y = _room.Height - 1;
                        break;
                    case "East":
                        x = _room.Width - 1;
                        y = _room.Height / 2;
                        break;
                    case "West":
                        x = 0;
                        y = _room.Height / 2;
                        break;
                }
                grid[x, y] = symbol;
            }
        }

        private void InitializeGrid()
        {
            var wallSymbol = new ConsoleText("#", ConsoleColor.Yellow);

            for (int x = 0; x < _room.Width; x++)
            {
                for (int y = 0; y < _room.Height; y++)
                {
                    if (x == 0 || y == 0 || x == _room.Width - 1 || y == _room.Height - 1)
                    {
                        grid[x, y] = wallSymbol; // Wall
                    }
                    else
                    {
                        grid[x, y] = new ConsoleText(" ", ConsoleColor.White); // Empty space
                    }
                }
            }
        }

        private ConsoleText GetItemSymbol(Item item)
        {
            switch (item)
            {
                case SankaraStone _:
                    return new ConsoleText("S", ConsoleColor.DarkRed);
                case Key key:
                    return new ConsoleText("K", GetColorFromString(key.Color));
                case PressurePlate _:
                    return new ConsoleText("T", ConsoleColor.Blue);
                case DisappearingBT _:
                    return new ConsoleText("@", ConsoleColor.Magenta);
                case BoobyTrap _:
                    return new ConsoleText("O", ConsoleColor.Cyan);
                // Add cases for other item types as needed
                default:
                    return new ConsoleText("?", ConsoleColor.White);
            }
        }

        private ConsoleText GetDoorSymbol(IConnection connection)
        {
            if (connection is Door door)
            {
                string direction = _room._connections.FirstOrDefault(kvp => kvp.Value == connection).Key;
                char symbol = (direction == "North" || direction == "South") ? '=' : '|'; // Choose symbol based on direction
                ConsoleColor doorColor = GetColorFromString(door.DoorColor);

                switch (door.FirstDecoratorType)
                {
                    case nameof(ColoredDoorDecorator):
                        // Assuming we have a way to get the color from the first decorator
                        return new ConsoleText(symbol.ToString(), doorColor);

                    case nameof(ToggleDoorDecorator):
                        return new ConsoleText("⊥", ConsoleColor.Green);

                    case nameof(ClosingGateDecorator):
                        return new ConsoleText("∩", ConsoleColor.Gray);

                    case nameof(OpenOnOddDoorDecorator):
                        return new ConsoleText(symbol.ToString(), ConsoleColor.Yellow);

                    case nameof(OpenOnStonesInRoomDoorDecorator):
                        return new ConsoleText(symbol.ToString(), ConsoleColor.Blue);

                    case nameof(BasicDoor):
                        return new ConsoleText(" ", ConsoleColor.White);

                    default:
                        return new ConsoleText(" ", ConsoleColor.White); // Default for unknown door types
                }
            }

            return new ConsoleText("?", ConsoleColor.White); // Default if not a door
        }

        private ConsoleColor GetColorFromString(string color)
        {
            switch (color?.ToLower())
            {
                case "red":
                    return ConsoleColor.Red;
                case "green":
                    return ConsoleColor.Green;
                case "blue":
                    return ConsoleColor.Blue;
                case "yellow":
                    return ConsoleColor.Yellow;
                case "orange":
                    return ConsoleColor.DarkYellow;
                case "magenta":
                    return ConsoleColor.Magenta;
                case "cyan":
                    return ConsoleColor.Cyan;
                case "gray":
                    return ConsoleColor.Gray;
                // Add more color mappings as needed
                default:
                    return ConsoleColor.White;
            }
        }



    }
}
