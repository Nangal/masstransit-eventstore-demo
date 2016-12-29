using System;

namespace Contracts.Commands
{
    public interface CreateGebruiker : Command
    {
        string BsnSofinummer { get; set; }
    }
}
