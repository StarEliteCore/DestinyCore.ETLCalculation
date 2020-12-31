using System;

namespace DestinyCore.ETLCalculation.Shared.Helpers
{
    public static class ArrayHelper
    {
        public static T[] Empty<T>() =>
            Array.Empty<T>()
        ;

    }
}