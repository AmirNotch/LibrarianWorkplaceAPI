using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace LibrarianWorkplaceAPI.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            Log.Information("Notes Request: {@Request} ", request);

            var response = await next();

            return response;
        }
    }
}