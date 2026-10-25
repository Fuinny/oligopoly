namespace Oligopoly.Models;

internal sealed class Player
{
    public required decimal Money { get; set; }

    public decimal NetWorth { get; set; } = 0M;
    public Dictionary<string, int> Portfolio { get; init; } = [];
}
