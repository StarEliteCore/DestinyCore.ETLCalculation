﻿using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Shared.Events
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IEventHandlerBase<in TEvent> where TEvent : class, IEventBase
    {
        Task Handle(TEvent notification, CancellationToken cancellationToken);
    }
}