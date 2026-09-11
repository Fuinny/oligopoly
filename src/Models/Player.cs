namespace Oligopoly.Models;

internal sealed class Player
{
    public required int ActionPoints { get; set; }
    public required decimal Money { get; set; }

    public decimal NetWorth { get; set; } = 0;
    public Dictionary<string, int> Portfolio { get; set; } = new();
}