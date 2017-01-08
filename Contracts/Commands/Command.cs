using System;

namespace Contracts.Commands
{
    public interface Command
    {
        Guid Id { get; set; }
    }
}
