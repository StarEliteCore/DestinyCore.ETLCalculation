using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.Migrations
{
    public partial class DestinyETL_20210411_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceConnectionId",
                table: "ETL_ScheduleTask");

            migrationBuilder.DropColumn(
                name: "SourceTable",
                table: "ETL_ScheduleTask");

            migrationBuilder.DropColumn(
                name: "TargetConnectionId",
                table: "ETL_ScheduleTask");

            migrationBuilder.DropColumn(
                name: "TargetTable",
                table: "ETL_ScheduleTask");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SourceConnectionId",
                table: "ETL_ScheduleTask",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SourceTable",
                table: "ETL_ScheduleTask",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TargetConnectionId",
                table: "ETL_ScheduleTask",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "TargetTable",
                table: "ETL_ScheduleTask",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
