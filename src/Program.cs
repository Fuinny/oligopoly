using Oligopoly.UI;

try
{
    Terminal.Setup();

    SelectionMenu mainMenu = new(Titles.MainTitle,
        new("Play"),
        new("Load"),
        new("Settings"),
        new("About Game"),
        new("Exit")
    );

    mainMenu.Show();
}
catch
{
    Terminal.Reset();
}
