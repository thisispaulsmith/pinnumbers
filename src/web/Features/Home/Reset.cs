using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Web.Infrastructure.Data;

namespace Web.Features.Home
{
    public class Reset
    {
        public class Command : IRequest<Result>
        {
        }

        public class Result
        {
            public bool Success { get; set; }
        }

        public class QueryHandler : IRequestHandler<Command, Result>
        {
            PinDataContext _context;

            public QueryHandler(PinDataContext context)
            {
                _context = context;
            }

            public async Task<Result> Handle(Command query, CancellationToken cancellationToken)
            {
                using (var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    var sql = "UPDATE dbo.PinNumbers SET Consumed = 0";
                    await connection.ExecuteAsync(sql);
                }

                return new Result { Success = true };
            }
        }
    }
}
