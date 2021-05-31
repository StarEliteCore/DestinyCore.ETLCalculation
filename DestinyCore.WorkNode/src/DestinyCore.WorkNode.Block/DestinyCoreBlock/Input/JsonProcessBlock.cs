using DestinyCore.WorkNode.Block.FLowkDataTransMission;
using DestinyCore.WorkNode.BlockOption.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Json.Path;

namespace DestinyCore.WorkNode.Block.DestinyCoreBlock.Input
{
    public class JsonProcessBlock<IDataTransMission> : IPropagatorBlock<IDataTransMission, IDataTransMission>, IReceivableSourceBlock<IDataTransMission>
    {
        public readonly DataTransMission _datatransmission;
        /// <summary>
        /// 私有来源表变量
        /// </summary>
        private readonly IReceivableSourceBlock<IDataTransMission> m_source;
        /// <summary>
        /// 目标连接块
        /// </summary>
        private readonly ITargetBlock<IDataTransMission> m_target;
        public JsonProcessBlock(JsonReadContent content)
        {
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(content.JsonString));
            if (!JsonDocument.TryParseValue(ref reader, out var rootElement))
            {
                //非法json字符串
                return;
            }
            
            _datatransmission = new DataTransMission();
            
            foreach (var p in content.JsonReadConfig)
            {
                if (!JsonPath.TryParse(p.PathField, out var path))
                {
                    //json path不符合规范
                    continue;
                }

                Debug.Assert(path != null, nameof(path) + " != null");
                var field = path.Evaluate(rootElement.RootElement);
                if (!field.Matches.Any())
                {
                    //找不到匹配的字段
                    continue;
                }

                var fieldMatch = field.Matches.Single();
                var name = fieldMatch.Location.Segments.Single().Source;
                if (_datatransmission.Table.Columns.Contains(name))
                {
                    // _datatransmission.Table.Rows
                }



            }
            //传播器的源部分包含大小为readJsonConfig的对象并将数据传播到任何连接的目标。
            var source = new BufferBlock<IDataTransMission>();
            // 目标部件接收数据并将其添加到队列中。
            var target = new ActionBlock<IDataTransMission>(item =>
            {
               
            });

            // 当目标设置为完成状态时，传播任何并将源设置为已完成状态。
            target.Completion.ContinueWith(delegate
            {
                source.Complete();
            });
            
            m_target = target;
            m_source = source;
        }
        // 获取数据
        public DataTransMission Data { get { return _datatransmission; } }



        #region IDataflowBlock 数据流块成员
        /// <summary>
        /// 获取表示当前数据流块完成的任务。
        /// </summary>
        public Task Completion { get { return m_source.Completion; } }
        /// <summary>
        /// 向此目标块发出信号，表示它不应再接受任何消息，也不使用延迟的消息。
        /// </summary>
        public void Complete()
        {
            m_target.Complete();
        }
        /// <summary>
        /// 断层故障处理
        /// </summary>
        /// <param name="exception"></param>
        public void Fault(Exception exception)
        {
            m_target.Fault(exception);
        }
        #endregion

        #region ISourceBlock 源块成员
        /// <summary>
        /// 将此数据流块链接到下一目标。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="linkOptions"></param>
        /// <returns></returns>
        public IDisposable LinkTo(ITargetBlock<IDataTransMission> target, DataflowLinkOptions linkOptions)
        {
            return m_source.LinkTo(m_target, linkOptions);
        }
        /// <summary>
        /// 由目标调用以使用来自源的先前提供的消息。
        /// </summary>
        /// <param name="messageHeader"></param>
        /// <param name="target"></param>
        /// <param name="messageConsumed"></param>
        /// <returns></returns>
        IDataTransMission ISourceBlock<IDataTransMission>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<IDataTransMission> target, out bool messageConsumed)
        {
            return m_source.ConsumeMessage(messageHeader,
               target, out messageConsumed);
        }
        /// <summary>
        /// 由目标调用以保留源以前提供的消息,但还没有被这个目标消耗掉。
        /// </summary>
        /// <param name="messageHeader"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        bool ISourceBlock<IDataTransMission>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<IDataTransMission> target)
        {
            return m_source.ReserveMessage(messageHeader, target);
        }
        /// <summary>
        /// 由目标调用以从源释放先前保留的消息。
        /// </summary>
        /// <param name="messageHeader"></param>
        /// <param name="target"></param>
        void ISourceBlock<IDataTransMission>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<IDataTransMission> target)
        {
            m_source.ReleaseReservation(messageHeader, target);
        }
        #endregion

        #region  IReceivableSourceBlock 可接收源块<TOutput>成员
        /// <summary>
        /// 尝试从源同步接收项目。
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryReceive(Predicate<IDataTransMission> filter, out IDataTransMission item)
        {
            return m_source.TryReceive(filter, out item);
        }
        /// <summary>
        /// 尝试将源中的所有可用元素删除到新的返回的数组。
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool TryReceiveAll(out IList<IDataTransMission> items)
        {
            return m_source.TryReceiveAll(out items);
        }
        #endregion

        #region  ITargetBlock 目标数成员处理
        /// <summary>
        /// 异步地将消息传递给目标块，给目标消费信息的机会。
        /// </summary>
        /// <param name="messageHeader"></param>
        /// <param name="messageValue"></param>
        /// <param name="source"></param>
        /// <param name="consumeToAccept"></param>
        /// <returns></returns>
        DataflowMessageStatus ITargetBlock<IDataTransMission>.OfferMessage(DataflowMessageHeader messageHeader, IDataTransMission messageValue, ISourceBlock<IDataTransMission> source, bool consumeToAccept)
        {
            return m_target.OfferMessage(messageHeader,
               messageValue, source, consumeToAccept);
        }
        #endregion


    }
}
