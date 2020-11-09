using App.Common.Exceptions;
using FluentValidation;
using MediatR;
using SeekQ.MyConnections.Api.Domain.ConnectionsAggregate;
using SeekQ.MyConnections.Api.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.MyConnections.Api.Application.Commands
{
    public class UnblockUserCommandHandler
    {
        public class Command : IRequest<bool>
        {
            public Guid Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotNull().NotEmpty().WithMessage("The connection Id is required");
            }

            private object RuleFor(Func<object, object> p)
            {
                throw new NotImplementedException();
            }
        }

        public class Handler : IRequestHandler<Command, bool>
        {

            private MyConnectionsDbContext _myConnectionsDbContext;

            public Handler(MyConnectionsDbContext myConnectionsDbContext)
            {
                _myConnectionsDbContext = myConnectionsDbContext;
            }

            public async Task<bool> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                Guid id = request.Id;

                Connection existingConnection = _myConnectionsDbContext.Connections.Find(id);

                if (existingConnection != null)
                {
                    existingConnection.Blocked = false;
                    _myConnectionsDbContext.Connections.Update(existingConnection);
                    return await _myConnectionsDbContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new AppException($"The connection Id {id} already as not been found");
                }
            }
        }
    }
}
