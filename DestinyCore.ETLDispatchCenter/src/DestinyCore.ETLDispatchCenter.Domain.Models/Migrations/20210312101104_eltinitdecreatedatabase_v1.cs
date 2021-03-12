using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.Migrations
{
    public partial class eltinitdecreatedatabase_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataDictionary",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(maxLength: 50, nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    Sort = table.Column<int>(nullable: false, defaultValue: 0),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifyId = table.Column<Guid>(nullable: true),
                    LastModifedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ETL_DBConnection",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConnectionName = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Host = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    DBType = table.Column<int>(nullable: false),
                    MaxConnSize = table.Column<int>(nullable: false),
                    DataBase = table.Column<string>(nullable: true),
                    CreatedId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifyId = table.Column<Guid>(nullable: true),
                    LastModifedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETL_DBConnection", x => x.Id);
                },
                comment: "数据库连接管理");

            migrationBuilder.CreateTable(
                name: "ETL_ScheduleTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TaskNumber = table.Column<string>(nullable: true),
                    TaskName = table.Column<string>(nullable: true),
                    TaskType = table.Column<int>(nullable: false),
                    TaskConfig = table.Column<string>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    SourceConnectionId = table.Column<Guid>(nullable: false),
                    TargetConnectionId = table.Column<Guid>(nullable: false),
                    SourceTable = table.Column<string>(nullable: true),
                    TargetTable = table.Column<string>(nullable: true),
                    CreatedId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifyId = table.Column<Guid>(nullable: true),
                    LastModifedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETL_ScheduleTask", x => x.Id);
                },
                comment: "任务管理");

            migrationBuilder.CreateTable(
                name: "ETL_DBMetaData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MetaDataType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ConnectionId = table.Column<Guid>(nullable: true),
                    Describe = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: false),
                    CreatedId = table.Column<Guid>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifyId = table.Column<Guid>(nullable: true),
                    LastModifedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ETL_DBMetaData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ETL_DBMetaData_ETL_DBConnection_ConnectionId",
                        column: x => x.ConnectionId,
                        principalTable: "ETL_DBConnection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "元数据管理");

            migrationBuilder.CreateIndex(
                name: "IX_ETL_DBMetaData_ConnectionId",
                table: "ETL_DBMetaData",
                column: "ConnectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataDictionary");

            migrationBuilder.DropTable(
                name: "ETL_DBMetaData");

            migrationBuilder.DropTable(
                name: "ETL_ScheduleTask");

            migrationBuilder.DropTable(
                name: "ETL_DBConnection");
        }
    }
}
