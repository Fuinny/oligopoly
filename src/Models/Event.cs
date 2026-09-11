namespace Oligopoly.Models;

internal sealed class Event
{
    public required int Id { get; set; }
    public required int Effect { get; set; }
    public required string Target { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
}