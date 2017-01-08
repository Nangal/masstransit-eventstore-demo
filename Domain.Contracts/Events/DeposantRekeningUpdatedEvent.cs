using System;
using Entities.Rekening;

namespace Domain.Contracts.Events
{
    public class DeposantRekeningUpdatedEvent
    {
        public Guid Id { get; set; }

        public Rekening Rekening { get; set; }
    }
}