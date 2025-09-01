using MediatR;

namespace RecipeApi;

public abstract class RequestHandlerBase<TRequest, TReturn> : IRequestHandler<TRequest, TReturn>
    where TRequest : IRequest<TReturn>
{
    public RequestHandlerBase() { }

    public abstract Task<TReturn> Handle(
        TRequest request,
        CancellationToken cancellationToken = default
    );
}
