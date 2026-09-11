namespace Oligopoly.Models;

internal sealed class Context
{
    public required Player CurrentPlayer { get; set; }
    public required List<Event> Events { get; set; }
    public required List<Event> GlobalEvents { get; set; }
    public required List<Company> Companies { get; set; }

    public int CurrentTurn { get; set; } = 1;
}