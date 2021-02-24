using DestinyCore.ETLDispatchCenter.Shared.Enums;
using System;

namespace DestinyCore.ETLDispatchCenter.Shared.Attributes.AutoMapper
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