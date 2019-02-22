using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Infrastructure;
using Web.Infrastructure.Data;
using Web.Models;

namespace Web.Features.Home
{
    public class Index
    {
        public class Command : IRequest<Result>
        {
        }

        public class Result
        {
            public string Pin { get; set; }

            public bool PinsAvailable { get; set; } = false;
        }

        public class CommandHandler : IRequestHandler<Command, Result>
        {
            PinDataContext _context;

            private static Random _random = new Random();

            public CommandHandler(PinDataContext context)
            {
                _context = context;
            }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                PinNumber pinNumber;

                using (var transaction = _context.Database.BeginTransaction())
                {
                    pinNumber = await _context.PinNumbers
                        .Where(p => p.Consumed == false)
                        .OrderBy(c => Guid.NewGuid())
                        .FirstOrDefaultAsync();

                    if (pinNumber != null)
                    { 
                        pinNumber.Consumed = true;

                        await _context.SaveChangesAsync();

                        transaction.Commit();
                    }
                }

                var pinNumbersAvailable = await _context.PinNumbers.AnyAsync(p => p.Consumed == false);

                return new Result() { Pin = pinNumber?.Pin, PinsAvailable = pinNumbersAvailable };
            }
        }
    }
}
