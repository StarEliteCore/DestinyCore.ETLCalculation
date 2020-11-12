using System;

namespace Destiny.Core.TaskScheduler.Shared.Attributes
{
    public abstract class AttributeBase : Attribute
    {
        public abstract string Description();
    }
}