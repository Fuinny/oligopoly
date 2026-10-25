namespace Oligopoly.Models;

internal sealed class Company
{
    public required string Id { get; init; }
    public required string Sphere { get; init; }
    public required string Name { get; init; }
    public required string[] Description { get; init; }
    public required decimal SharePrice { get; set; }
}
