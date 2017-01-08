using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Contracts.Commands;
using Domain.Services.Deposant;

namespace Domain.Deposant
{
    public class DeposantService : IDeposantService
    {
        private readonly IRepository _repository;

        public DeposantService(IRepository repository)
        {
            _repository = repository;
        }

        public string GenerateDeposantNummer()
        {
            var result = GenerateRandom(12, 0, 12);

            return string.Join(string.Empty, result);
        }

        public Guid When(CreateDeposant command)
        {
            var id = Guid.NewGuid();       

            Execute(id, deposant => deposant.Create(id, command.DeposantNummer));

            return id;
        }

        public void When(UpdateDeposantGegevens command)
        {
            var gegevens = command.DeposantGegevens;
            Execute(command.Id, deposant =>
            {
                deposant.UpdateGegevens(
                    gegevens.Naam, 
                    gegevens.Voornaam, 
                    gegevens.Adres, 
                    gegevens.Huisnummer, 
                    gegevens.Postcode, 
                    gegevens.Gemeente, 
                    gegevens.Land);
            });
        }

        public void When(UpdateDeposantRekening command)
        {
            var rekening = command.Rekening;
            Execute(command.Id, deposant =>
            {
                deposant.UpdateRekening(
                    rekening.RekeningNummer,
                    rekening.Bic,
                    rekening.Saldo,
                    rekening.Valuta);
            });
        }

        public void When(BepaalDeposantAanspraak command)
        {
            var aanspraak = command.Aanspraak;
            Execute(command.Id, deposant =>
            {
                deposant.BepaalAanspraak(
                    aanspraak.Saldo,
                    aanspraak.Bepaald    
                );
            });
        }

        public void When(BepaalDeposantBesluitInformatie command)
        {
            var besluitInformatie = command.BesluitInformatie;
            Execute(command.Id, deposant =>
            {
                deposant.BepaalBesluitInformatie(
                    besluitInformatie.Besluit,
                    besluitInformatie.Aanspraak
                );
            });
        }

        private void Execute(Guid id, Action<Deposant> action)
        {
            var deposant = _repository.GetById<Deposant>(id);
            action(deposant);
            _repository.Save(deposant);
        }

        private readonly Random _random = new Random();

        // Note, max is exclusive here!
        private List<int> GenerateRandom(int count, int min, int max)
        {

            //  initialize set S to empty
            //  for J := N-M + 1 to N do
            //    T := RandInt(1, J)
            //    if T is not in S then
            //      insert T in S
            //    else
            //      insert J in S
            //
            // adapted for C# which does not have an inclusive Next(..)
            // and to make it from configurable range not just 1.

            if (max <= min || count < 0 ||
                    // max - min > 0 required to avoid overflow
                    (count > max - min && max - min > 0))
            {
                // need to use 64-bit to support big ranges (negative min, positive max)
                throw new ArgumentOutOfRangeException("Range " + min + " to " + max +
                        " (" + ((Int64)max - (Int64)min) + " values), or count " + count + " is illegal");
            }

            // generate count random values.
            HashSet<int> candidates = new HashSet<int>();

            // start count values before max, and end at max
            for (int top = max - count; top < max; top++)
            {
                // May strike a duplicate.
                // Need to add +1 to make inclusive generator
                // +1 is safe even for MaxVal max value because top < max
                if (!candidates.Add(_random.Next(min, top + 1)))
                {
                    // collision, add inclusive max.
                    // which could not possibly have been added before.
                    candidates.Add(top);
                }
            }

            // load them in to a list, to sort
            List<int> result = candidates.ToList();

            // shuffle the results because HashSet has messed
            // with the order, and the algorithm does not produce
            // random-ordered results (e.g. max-1 will never be the first value)
            for (int i = result.Count - 1; i > 0; i--)
            {
                int k = _random.Next(i + 1);
                int tmp = result[k];
                result[k] = result[i];
                result[i] = tmp;
            }
            return result;
        }             
    }
}
