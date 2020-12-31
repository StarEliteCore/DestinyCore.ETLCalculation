using DestinyCore.ETLCalculation.Shared.Enums;
using System;

namespace DestinyCore.ETLCalculation.Shared.Attributes.AutoMapper
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SuktAutoMapFromAttribute : SuktAutoMapperAttribute
    {
        public override SuktAutoMapDirection MapDirection
        {
            get { return SuktAutoMapDirection.From; }
        }

        public SuktAutoMapFromAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {
        }
    }
}