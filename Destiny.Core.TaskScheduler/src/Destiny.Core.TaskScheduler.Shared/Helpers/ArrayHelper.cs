using System;

namespace Destiny.Core.TaskScheduler.Shared.Helpers
{
    public static class ArrayHelper
    {
        public static T[] Empty<T>() =>
            Array.Empty<T>()
        ;

    }
}