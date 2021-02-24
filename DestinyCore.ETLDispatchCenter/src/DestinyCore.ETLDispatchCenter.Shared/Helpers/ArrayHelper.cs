using System;

namespace DestinyCore.ETLDispatchCenter.Shared.Helpers
{
    public static class ArrayHelper
    {
        public static T[] Empty<T>() =>
            Array.Empty<T>()
        ;

    }
}