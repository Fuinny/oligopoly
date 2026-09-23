namespace Oligopoly.Models;

internal sealed class News
{
    public required string Id { get; init; }
    public required string Target { get; init; }
    public required string Title { get; init; }
    public required string Content { get; init; }
    public required decimal Effect { get; init; }
}
