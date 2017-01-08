using System;
using Entities.Aanspraak;

namespace Domain.Contracts.Events
{
    public class DeposantAanspraakBepaaldEvent
    {
        public Guid Id { get; set; }

        public Aanspraak Aanspraak { get; set; }
    }
}