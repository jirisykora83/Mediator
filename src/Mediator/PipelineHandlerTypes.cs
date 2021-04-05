using System.Threading;
using System.Threading.Tasks;

namespace Mediator
{
    public delegate ValueTask<TResponse> MessageHandlerDelegate<TMessage, TResponse>(TMessage message, CancellationToken cancellationToken)
        where TMessage : IMessage;

    public delegate ValueTask MessageHandlerDelegate<TMessage>(TMessage message, CancellationToken cancellationToken)
        where TMessage : IMessage;

    public interface IPipelineBehavior<TMessage, TResponse>
        where TMessage : IMessage
    {
        ValueTask<TResponse> Handle(TMessage message, CancellationToken cancellationToken, MessageHandlerDelegate<TMessage, TResponse> next);
    }

    public interface IPipelineBehavior<TMessage>
        where TMessage : IMessage
    {
        ValueTask Handle(TMessage message, CancellationToken cancellationToken, MessageHandlerDelegate<TMessage> next);
    }
}