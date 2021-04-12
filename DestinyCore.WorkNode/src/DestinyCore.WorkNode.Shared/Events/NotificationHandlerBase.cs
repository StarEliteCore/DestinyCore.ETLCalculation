using MediatR;

namespace DestinyCore.WorkNode.Shared.Events
{
    public abstract class NotificationHandlerBase<TEvent> : EventHandlerBase<TEvent>, INotificationHandler<TEvent> where TEvent : EventBase
    {
    }
}