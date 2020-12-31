using DestinyCore.ETLCalculation.Shared.Enums;
using System;

namespace DestinyCore.ETLCalculation.Shared.Attributes.AutoMapper
{
    public class SuktAutoMapToAttribute : SuktAutoMapperAttribute
    {
        public override SuktAutoMapDirection MapDirection
        {
            get { return SuktAutoMapDirection.From; }
        }

        public SuktAutoMapToAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {
        }
    }
}