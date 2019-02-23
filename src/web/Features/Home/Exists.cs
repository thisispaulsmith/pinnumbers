using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Infrastructure;
using Web.Infrastructure.Data;

namespace Web.Features.Home
{
    public class Exists
    {
        public class Query : IRequest<Result>
        {
            public string Pin { get; set; }
        }

        public class Result
        {
            public string Pin { get; set; }
            public bool Exists { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Result>
        {
            PinDataContext _context;

            public QueryHandler(PinDataContext context)
            {
                _context = context;
            }

            public async Task<Result> Handle(Query query, CancellationToken cancellationToken)
            {
                return new Result()
                {
                    Pin = query.Pin,
                    Exists = await _context.PinNumbers.AnyAsync(p => p.Pin == query.Pin && p.Consumed == true)
                };
            }
        }
    }
}
