using System.Text;

namespace Oligopoly.UI;

internal static class Terminal
{
    private static readonly Encoding OriginalEncoding = Console.OutputEncoding;

    internal static void Clear()
    {
        Console.Write("\e[2J\e[H");
    }

    internal static void Setup()
    {
        Console.CursorVisible = false;
        Console.TreatControlCAsInput = true;
        Console.OutputEncoding = Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Write("\e[?1049h"); // Enables the alternative buffer.
    }

    internal static void Reset()
    {
        Console.CursorVisible = true;
        Console.TreatControlCAsInput = false;
        Console.OutputEncoding = OriginalEncoding;
        Console.ResetColor();
        Console.Write("\e[?1049l"); // Disables the alternative buffer.
    }
}
