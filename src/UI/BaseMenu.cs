namespace Oligopoly.UI;

internal abstract class BaseMenu<TResult>
{
    private protected bool Exit { get; set; } = false;

    internal int SelectedIndex { get; set; } = 0;

    private protected abstract void DrawContent();
    private protected abstract void HandleKeyPress(ConsoleKeyInfo keyPressedInfo);
    private protected abstract TResult GetResult();

    private static void DrawBorder()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write('╔' + new string('═', Console.WindowWidth - 2) + '╗');

        for (int currentRow = 1; currentRow < Console.WindowHeight - 1; currentRow++)
        {
            Console.SetCursorPosition(0, currentRow);
            Console.Write('║');
            Console.SetCursorPosition(Console.WindowWidth - 1, currentRow);
            Console.Write('║');
        }

        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.Write('╚' + new string('═', Console.WindowWidth - 2) + '╝');

        Console.SetCursorPosition(1, 1);
    }

    private void DrawMenu()
    {
        Terminal.Clear();
        DrawBorder();
        DrawContent();
    }

    private protected static void CenterLine(string line, bool highlighted = false)
    {
        // This also prevents line wraps on console resize.
        if (line.Length > Console.WindowWidth - 2) return;

        Console.CursorLeft = (Console.WindowWidth - line.Length) / 2;

        if (highlighted)
            (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor);

        Console.WriteLine(line);

        if (highlighted)
            (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor);
    }

    internal TResult Show()
    {
        int lastConsoleWidth = Console.WindowWidth;
        int lastConsoleHeight = Console.WindowHeight;

        DrawMenu();

        while (!Exit)
        {
            while (!Console.KeyAvailable)
            {
                if (Console.WindowWidth != lastConsoleWidth || Console.WindowHeight != lastConsoleHeight)
                {
                    lastConsoleWidth = Console.WindowWidth;
                    lastConsoleHeight = Console.WindowHeight;
                    DrawMenu();
                }

                Thread.Sleep(33);
            }

            ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
            HandleKeyPress(keyPressedInfo);

            if (!Exit) DrawMenu();
        }

        return GetResult();
    }
}
