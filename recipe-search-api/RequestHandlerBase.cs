using MediatR;

namespace RecipeApi;

public abstract class RequestHandlerBase<TRequest, TReturn> : IRequestHandler<TRequest, TReturn> where TRequest : IRequest<TReturn>
{
    //In the origonal this also had several functions that reached out to the iothub
    //IHttpClientFactory httpClientFactory;
    public RequestHandlerBase(
        //IHttpClientFactory httpClientFactory
    )
    {
        //this.httpClientFactory = httpClientFactory;
    }

    public abstract Task<TReturn> Handle(TRequest request, CancellationToken cancellationToken = default);


}