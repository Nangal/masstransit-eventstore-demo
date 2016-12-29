using System;

namespace Contracts.Commands
{
    public interface CreateDeposant : Command
    {
        string DeposantNummer { get; set; }
    }
}
