namespace Oligopoly.Models;

internal sealed class Context
{
    public required List<News> AllNews { get; init; }
    public required List<Company> AllCompanies { get; init; }
    public required Player CurrentPlayer { get; init; }

    public int CurrentTurn { get; set; } = 0;
    public int SkipTurnCounter { get; set; } = 0;

    internal const int SkipTurnLimit = 5;
}
