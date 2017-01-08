using System;
using Entities.BesluitInformatie;

namespace Domain.Contracts.Events
{
    public class DeposantBesluitInformatieBepaaldEvent
    {
        public Guid Id { get; set; }

        public BesluitInformatie BesluitInformatie { get; set; }
    }
}