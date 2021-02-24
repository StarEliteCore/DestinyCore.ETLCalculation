namespace DestinyCore.ETLDispatchCenter.Shared.Entity
{
    public class InputDto<Tkey> : IInputDto<Tkey>
    {
        public virtual Tkey Id { get; set; }
    }
}