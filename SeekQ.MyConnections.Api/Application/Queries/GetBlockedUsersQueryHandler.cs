using App.Common.SeedWork;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.MyConnections.Api.Application.Queries
{
    public class GetBlockedUsersQueryHandler
    {
        public class Query : IRequest<IEnumerable<GetBlockedUsersrViewModel>>
        {
            public Query(Guid idUser)
            {
                IdUser = idUser;
            }

            public Guid IdUser { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<GetBlockedUsersrViewModel>>
        {
            private CommonGlobalAppSingleSettings _commonGlobalAppSingleSettings;

            public Handler(CommonGlobalAppSingleSettings commonGlobalAppSingleSettings)
            {
                _commonGlobalAppSingleSettings = commonGlobalAppSingleSettings;
            }

            public async Task<IEnumerable<GetBlockedUsersrViewModel>> Handle(
                Query query,
                CancellationToken cancellationToken)
            {
                using (IDbConnection conn = new SqlConnection(_commonGlobalAppSingleSettings.MssqlConnectionString))
                {
                    string sql =
                        @"
                        SELECT 
	                        c.Id as IdConnection, c.ConnectionAvatar as Avatar, CONCAT(c.ConnectionFirstName, ' ', c.ConnectionLastName) as FullName, c.ConnectionAge as Age, c.ConnectionUserId as ConnectionUserId
                        FROM 
	                        Connections c
		                WHERE c.IdUser = @IdUser AND c.Blocked = 1";

                    var result = await conn.QueryAsync<GetBlockedUsersrViewModel>(sql, new { IdUser = query.IdUser });

                    return result;
                }
            }
        }
    }
}
