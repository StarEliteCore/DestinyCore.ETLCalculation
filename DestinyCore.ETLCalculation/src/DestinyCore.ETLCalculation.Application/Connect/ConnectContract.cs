using DestinyCore.ETLCalculation.Dtos;
using DestinyCore.ETLCalculation.Shared.Extensions;
using Microsoft.Extensions.Logging;
using SuperSocket.Client;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DestinyCore.ETLCalculation.Application.Connect
{
    public class ConnectContract : IConnectContract
    {
        private readonly IServiceProvider _serviceProvider = null;
        private readonly ILogger _logger;
        public IEasyClient<StringPackageInfo> Client { get; set; }
        private bool reconnection = false;

        public ConnectContract(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = _serviceProvider.GetLogger<ILogger>();
        }

        public async Task ConnectAsync()
        {
            _logger.LogInformation("Client start Befor");
            //接收消息事件
            Client.PackageHandler += ReceiveMessage;
            //断开重连事件
            Client.Closed += Reconnection;
            //客户端连接
            var connected = await Client.ConnectAsync(new IPEndPoint(IPAddress.Loopback, 4052));
            _logger.LogInformation($"Client start Befor.");
            if (!connected)
            {
                _logger.LogError($"Client start Failed to connect the target server.");
                return;
            }
            _logger.LogInformation($"Client Susccess End ");
            //await Client.SendAsync(Encoding.UTF8.GetBytes($"ReceiveMessage 毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒\r\n"));
            //接收
            Client.StartReceive();
            while (true)
            {

            }
        }
        async ValueTask ReceiveMessage(IEasyClient<StringPackageInfo> client, StringPackageInfo packageInfo)
        {
            await Task.CompletedTask;
            List<Task> tasks = new List<Task>();
            var bogylist = packageInfo.Body.FromJson<List<PerformParameter>>();
            _logger.LogInformation($"Client Receive Message {packageInfo.Body}");
            //foreach (var item in bogylist)
            //{
            //    tasks.Add(
            //        Task.Run(() =>
            //        {
            //            _startProcessContract.StartTaskFunc(item);
            //        }));
            //}
            //await Task.WhenAll(tasks.ToArray());
            Console.WriteLine($"--------------------{ packageInfo.Body}");
        }
        void Reconnection(object sender, EventArgs e)
        {
            Client.PackageHandler -= ReceiveMessage;
            Client.Closed -= Reconnection;
            while (!reconnection)
            {
                Console.WriteLine("重新连接失败");
                reconnection = Task.Run(async () => await Client.ConnectAsync(new IPEndPoint(IPAddress.Loopback, 4052))).Result;
            };
            if (reconnection)
            {
                Console.WriteLine("重新连接成功");
                reconnection = false;
                Client.PackageHandler += ReceiveMessage;
                Client.Closed += Reconnection;
                Client.StartReceive();
            }
        }
    }
}
