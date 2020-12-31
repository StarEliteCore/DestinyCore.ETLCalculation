using System.ComponentModel;

namespace DestinyCore.ETLCalculation.Shared.Entity
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity
    {
        [Description("主键")]
        TKey Id { get; }
    }
}