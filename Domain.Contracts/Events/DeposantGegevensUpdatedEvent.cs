using System;
using Entities.Gegevens;

namespace Domain.Contracts.Events
{
    public class DeposantGegevensUpdatedEvent
    {
        public Guid Id { get; set; }

        public Gegevens DeposantGegevens { get; set; }
    }
}