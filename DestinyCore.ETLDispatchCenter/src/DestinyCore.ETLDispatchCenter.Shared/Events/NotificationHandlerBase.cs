using MediatR;

namespace DestinyCore.ETLDispatchCenter.Shared.Events
{
    public abstract class NotificationHandlerBase<TEvent> : EventHandlerBase<TEvent>, INotificationHandler<TEvent> where TEvent : EventBase
    {
    }
}