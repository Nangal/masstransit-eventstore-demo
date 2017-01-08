using System;
using Entities.Rekening;

namespace Domain.Contracts.Commands
{
    public class UpdateDeposantRekening
    {
        public Guid Id { get; set; }

        public Rekening Rekening { get; set; }
    }
}