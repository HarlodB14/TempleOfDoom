namespace TempleOfDoomView.ViewModels
{
    public class ConsoleText
    {
        public ConsoleText(string text, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Text = text;
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }

        public string Text { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public ConsoleColor BackgroundColor { get; set; }
    }
}