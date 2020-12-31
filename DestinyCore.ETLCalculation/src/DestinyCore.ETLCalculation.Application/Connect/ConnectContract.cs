using DestinyCore.ETLCalculation.Dtos;
using DestinyCore.ETLCalculation.Shared.Extensions;
using SuperSocket.Client;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DestinyCore.ETLCalculation.Application.Connect
{
    public class ConnectContract : IConnectContract
    {
        public IEasyClient<StringPackageInfo> Client { get; set; }
        private bool reconnection = false;
        public async Task ConnectAsync()
        {
            Console.WriteLine("Client start.");
            //接收消息事件
            Client.PackageHandler += ReceiveMessage;
            //断开重连事件
            Client.Closed += Reconnection;
            #region 废弃代码
            //Client.Closed += async (s, p) =>
            //{
            //    while (!reconnection)
            //    {
            //        reconnection = await Client.ConnectAsync(new IPEndPoint(IPAddress.Parse("10.1.10.172"), 4052));
            //    }
            //    Console.WriteLine("重新连接成功");
            //    Client.PackageHandler += ReceiveMessage;
            //    Client.Closed += Reconnection;
            //    Client.StartReceive();
            //};

            //接收消息
            //Client.PackageHandler += async (s, p) =>
            //{
            //    List<Task> tasks = new List<Task>();
            //    var bogylist = p.Body.FromJson<List<PerformParameter>>();
            //    foreach (var item in bogylist)
            //    {
            //        tasks.Add(
            //            Task.Run(() =>
            //            {
            //                _startProcessContract.StartTaskFunc(item);
            //            }));
            //    }
            //    Task.WhenAll(tasks.ToArray());
            //    Console.WriteLine($"--------------------{ p.Body}");
            //    await Task.CompletedTask;
            //};
            #endregion
            //客户端连接
            var connected = await Client.ConnectAsync(new IPEndPoint(IPAddress.Loopback, 4052));
            if (!connected)
            {
                Console.WriteLine("Failed to connect the target server.");
                return;
            }
            System.Console.WriteLine("Client connect End.");
            await Client.SendAsync(Encoding.UTF8.GetBytes($"ReceiveMessage 毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒毒\r\n"));
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
