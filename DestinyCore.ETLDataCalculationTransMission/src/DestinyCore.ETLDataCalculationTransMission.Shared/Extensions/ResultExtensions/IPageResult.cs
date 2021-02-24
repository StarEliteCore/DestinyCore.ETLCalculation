namespace DestinyCore.ETLDataCalculationTransMission.Shared.Extensions.ResultExtensions
{
    public interface IPageResult<TModel> : IResultBase, IListResult<TModel>
    {
        int Total { get; }
    }
}