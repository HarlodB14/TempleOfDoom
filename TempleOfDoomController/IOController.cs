using TempleOfDoomModel;
using TempleOfDoomView;

namespace TempleOfDoomController
{
    public class IOController
    {
        private ConsoleInput consoleInput;
        private Game game;

        public IOController(Game game)
        {
            consoleInput = new ConsoleInput();
            this.game = game;
        }

        public void ProcessInput()
        {
            ConsoleKeyInfo keyInfo = consoleInput.GetInput();
            DirectionEnum direction = MapKeyToDirection(keyInfo.Key);
            game.player.Move(direction);
        }

        private DirectionEnum MapKeyToDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return DirectionEnum.North;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return DirectionEnum.South;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return DirectionEnum.West;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return DirectionEnum.East;

                default:
                    return DirectionEnum.North;
            }
        }

        private void MoveCursorBasedOnDirection(DirectionEnum direction)
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;

            int newLeft = currentLeft;
            int newTop = currentTop;

            switch (direction)
            {
                case DirectionEnum.North:
                    newTop = Math.Max(currentTop - 1, 0);
                    break;

                case DirectionEnum.South:
                    newTop = Math.Min(currentTop + 1, Console.WindowHeight - 1);
                    break;

                case DirectionEnum.West:
                    newLeft = Math.Max(currentLeft - 1, 0);
                    break;

                case DirectionEnum.East:
                    newLeft = Math.Min(currentLeft + 1, Console.WindowWidth - 1);
                    break;
            }

            Console.SetCursorPosition(newLeft, newTop);
        }


    }
}
