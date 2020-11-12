using Destiny.Core.TaskScheduler.Shared.Enums;
using System;

namespace Destiny.Core.TaskScheduler.Shared.Attributes.AutoMapper
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