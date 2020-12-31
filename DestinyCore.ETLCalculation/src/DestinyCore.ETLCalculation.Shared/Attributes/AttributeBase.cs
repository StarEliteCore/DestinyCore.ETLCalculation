using System;

namespace DestinyCore.ETLCalculation.Shared.Attributes
{
    public abstract class AttributeBase : Attribute
    {
        public abstract string Description();
    }
}