using System;
using Entities.Aanspraak;

namespace Domain.Contracts.Commands
{
    public class BepaalDeposantAanspraak
    {
        public Guid Id { get; set; }

        public Aanspraak Aanspraak { get; set; }
    }
}