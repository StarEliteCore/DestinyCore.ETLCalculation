using MediatR;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Events
{
    public abstract class NotificationHandlerBase<TEvent> : EventHandlerBase<TEvent>, INotificationHandler<TEvent> where TEvent : EventBase
    {
    }
}