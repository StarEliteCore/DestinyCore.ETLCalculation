using DestinyCore.ETLCalculation.Shared;
using SuperSocket.Client;
using SuperSocket.ProtoBase;
using System.Threading.Tasks;

namespace DestinyCore.ETLCalculation.Application.Connect
{
    public interface IConnectContract : IScopedDependency
    {
        IEasyClient<StringPackageInfo> Client { get; set; }
        Task ConnectAsync();
    }
}
