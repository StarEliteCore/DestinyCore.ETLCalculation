using System;

namespace DestinyCore.ETLDispatchCenter.Shared.Attributes
{
    public abstract class AttributeBase : Attribute
    {
        public abstract string Description();
    }
}