using System;
using Domain.Contracts.Commands;

namespace Domain.Services.Deposant
{
    public interface IDeposantService
    {
        string GenerateDeposantNummer();
        Guid When(CreateDeposant command);
        void When(UpdateDeposantGegevens command);
        void When(UpdateDeposantRekening command);
        void When(BepaalDeposantAanspraak command);
        void When(BepaalDeposantBesluitInformatie command);
    }
}