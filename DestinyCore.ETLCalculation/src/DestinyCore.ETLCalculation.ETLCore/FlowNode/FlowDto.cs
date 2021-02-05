using DestinyCore.ETLCalculation.ETLCore.FlowNode;
using System;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.ETLCore
{
    public class FlowDto
    {
        /// <summary>
        /// 数据节点
        /// </summary>
        public List<DataFlowNodeDto> Nodes = new List<DataFlowNodeDto>() {
            new DataFlowNodeDto()
            {
                Id=Guid.Parse("fbf59316-8d9d-7cf0-5fcb-74772beddbf7"),
                NodeType = NodeTypeEnum.InputTable,//输出
                NodeJson="",
                Title="抽取日志表数据",
                AssemblyType="",
                Describe="",
            },
            new DataFlowNodeDto()
            {
                Id=Guid.Parse("414ac4a1-883f-0e31-af20-9e510bc5805f"),
                NodeType = NodeTypeEnum.InputTable,//输入
                NodeJson="",
                Title="抽取产品表数据",
                AssemblyType="",
                Describe="",
            },
            new DataFlowNodeDto()
            {
                Id=Guid.Parse("890fdda4-91e0-c450-5697-5cf6be9bb368"),
                NodeType = NodeTypeEnum.InputExcel,//输入
                NodeJson="",
                Title="读取Excel数据",
                AssemblyType="",
                Describe="",
            },
            new DataFlowNodeDto()
            {
                Id=Guid.Parse("012d0790-8979-eba0-fd55-e103568b88bd"),
                NodeType = NodeTypeEnum.OutputTable,//输出
                NodeJson="",
                Title="读取日志数据到数据仓库日志表",
                AssemblyType="",
                Describe="",
            },
            new DataFlowNodeDto()
            {
                Id=Guid.Parse("349a763f-af29-0f9b-1003-1a854350d9da"),
                NodeType = NodeTypeEnum.OutputExcel,//输出
                NodeJson="",
                Title="读取数据到Excel表",
                AssemblyType="",
                Describe="",
            },
            new DataFlowNodeDto()
            {
                Id=Guid.Parse("f455ba9d-9452-228f-f37b-9bd76de73885"),
                NodeType = NodeTypeEnum.OutputTable,//输出
                NodeJson="",
                Title="读取Excel数据到数据表",
                AssemblyType="",
                Describe="",
            }
        };
        /// <summary>
        /// 线
        /// </summary>
        public List<DataFlowLineDto> Edges = new List<DataFlowLineDto>()
        {
            new DataFlowLineDto()
            {
                Source=new CellPortEntity
                {
                    Cell=Guid.Parse("fbf59316-8d9d-7cf0-5fcb-74772beddbf7"),
                    Port=Guid.NewGuid(),
                },
                Target=new CellPortEntity
                {
                    Cell=Guid.Parse("012d0790-8979-eba0-fd55-e103568b88bd"),
                    Port=Guid.NewGuid(),
                }
            },
            new DataFlowLineDto()
            {
                Source=new CellPortEntity
                {
                    Cell=Guid.Parse("414ac4a1-883f-0e31-af20-9e510bc5805f"),
                    Port=Guid.NewGuid(),
                },
                Target=new CellPortEntity
                {
                    Cell=Guid.Parse("349a763f-af29-0f9b-1003-1a854350d9da"),
                    Port=Guid.NewGuid(),
                }
            },
            new DataFlowLineDto()
            {
                Source=new CellPortEntity
                {
                    Cell=Guid.Parse("890fdda4-91e0-c450-5697-5cf6be9bb368"),
                    Port=Guid.NewGuid(),
                },
                Target=new CellPortEntity
                {
                    Cell=Guid.Parse("f455ba9d-9452-228f-f37b-9bd76de73885"),
                    Port=Guid.NewGuid(),
                }
            }
        };
    }
}
