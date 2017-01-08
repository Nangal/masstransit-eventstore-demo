using System;
using Entities.BesluitInformatie;

namespace Domain.Contracts.Commands
{
    public class BepaalDeposantBesluitInformatie
    {
        public Guid Id { get; set; }

        public BesluitInformatie BesluitInformatie { get; set; }
    }
}