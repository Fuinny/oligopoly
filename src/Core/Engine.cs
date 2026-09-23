using Oligopoly.UI;

namespace Oligopoly.Core;

internal enum GameState
{
    MainMenu,
    AboutGame,
    ConfirmExit,
    Exit
}

internal static class Engine
{
    private static int s_lastMainMenuSelected = 0;
    private static GameState s_currentGameState = GameState.MainMenu;

    internal static void Run()
    {
        while (s_currentGameState != GameState.Exit)
        {
            s_currentGameState = s_currentGameState switch
            {
                GameState.MainMenu => HandleMainMenu(),
                GameState.AboutGame => HandleAboutGameMenu(),
                GameState.ConfirmExit => HandleConfirmExitMenu(),
                _ => GameState.Exit
            };
        }
    }

    private static GameState HandleMainMenu()
    {
        SelectionMenu mainMenu = new(Titles.MainTitle,
            new("Play"),
            new("Load"),
            new("Settings"),
            new("About Game"),
            new("Exit")
        );

        mainMenu.SelectedIndex = s_lastMainMenuSelected;
        s_lastMainMenuSelected = mainMenu.Show();

        return s_lastMainMenuSelected switch
        {
            0 => GameState.MainMenu,
            1 => GameState.MainMenu,
            2 => GameState.MainMenu,
            3 => GameState.AboutGame,
            _ => GameState.ConfirmExit
        };
    }

    private static GameState HandleAboutGameMenu()
    {
        SelectionMenu aboutGameMenu = new(Titles.AboutGameTitle,
            new SelectionMenuItem("Back")
        );

        return aboutGameMenu.Show() switch
        {
            _ => GameState.MainMenu
        };
    }

    private static GameState HandleConfirmExitMenu()
    {
        SelectionMenu exitMenu = new(Titles.ConfirmExitTitle,
            new("Exit"),
            new("Back")
        );

        return exitMenu.Show() switch
        {
            1 => GameState.MainMenu,
            _ => GameState.Exit
        };
    }
}
