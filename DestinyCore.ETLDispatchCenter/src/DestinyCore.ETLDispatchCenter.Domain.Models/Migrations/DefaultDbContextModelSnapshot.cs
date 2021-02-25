﻿// <auto-generated />
using System;
using DestinyCore.ETLDispatchCenter.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DestinyCore.ETLDispatchCenter.Domain.Models.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource.DBConnection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConnectionName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedId")
                        .HasColumnType("char(36)");

                    b.Property<int>("DBType")
                        .HasColumnType("int");

                    b.Property<string>("Host")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModifedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("LastModifyId")
                        .HasColumnType("char(36)");

                    b.Property<int>("MaxConnSize")
                        .HasColumnType("int");

                    b.Property<string>("Memo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PassWord")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ETL_DBConnection");

                    b.HasComment("数据库连接管理");
                });

            modelBuilder.Entity("DestinyCore.ETLDispatchCenter.Domain.Models.SystemFoundation.DataDictionary.DataDictionaryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModifedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("LastModifyId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Remark")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Sort")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DataDictionary");
                });

            modelBuilder.Entity("DestinyCore.ETLDispatchCenter.Domain.Models.TaskConfig.ScheduleTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModifedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("LastModifyId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TaskConfig")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TaskName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TaskType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ETL_ScheduleTask");

                    b.HasComment("任务管理");
                });
#pragma warning restore 612, 618
        }
    }
}
