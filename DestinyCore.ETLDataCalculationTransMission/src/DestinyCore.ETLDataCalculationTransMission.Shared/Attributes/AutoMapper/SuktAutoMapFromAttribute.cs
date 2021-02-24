using DestinyCore.ETLDataCalculationTransMission.Shared.Enums;
using System;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Attributes.AutoMapper
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