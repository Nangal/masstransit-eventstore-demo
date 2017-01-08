using System;
using Entities.Gegevens;

namespace Domain.Contracts.Commands
{
    public class UpdateDeposantGegevens
    {
        public Guid Id { get; set; }

        public Gegevens DeposantGegevens { get; set; }
    }
}