namespace Oligopoly.Models;

internal sealed class Company
{
    public required string Id { get; set; }
    public required string Industry { get; set; }
    public required string Name { get; set; }
    public required string[] Description { get; set; }
    public required decimal SharePrice { get; set; }
}