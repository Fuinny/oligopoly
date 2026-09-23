using Oligopoly.UI;
using Oligopoly.Core;

try
{
    Terminal.Setup();
    Engine.Run();
}
finally
{
    Terminal.Reset();
}
