﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OfiCondo.Management.Persistence;

namespace OfiCondo.Management.Persistence.Migrations
{
    [DbContext(typeof(OfiCondoDbContext))]
    [Migration("20210805202656_ChangingInitialization")]
    partial class ChangingInitialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Attachment", b =>
                {
                    b.Property<Guid>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AttachmentId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Bank", b =>
                {
                    b.Property<Guid>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("BankId");

                    b.HasIndex("AccountId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("CategoryId");

                    b.HasIndex("AccountId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("01770ab3-1ae2-46d1-bc8c-5f2d48f29c26"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "NOMINA"
                        },
                        new
                        {
                            CategoryId = new Guid("cdfb7d9f-bc03-41b3-b429-85e0d836da06"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "GASTO GENERAL"
                        },
                        new
                        {
                            CategoryId = new Guid("fe8bf415-ee05-4b43-a20a-418988ad49dc"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "GAS"
                        },
                        new
                        {
                            CategoryId = new Guid("b2dcc802-3161-48be-8d91-94afbc460521"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "ENERGIA ELECTRICA"
                        },
                        new
                        {
                            CategoryId = new Guid("370d64f4-1d94-424e-859f-97e20541f538"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "AGUA"
                        },
                        new
                        {
                            CategoryId = new Guid("0bf4a844-1784-480f-b119-c6351c036e38"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "LIMPIEZA"
                        },
                        new
                        {
                            CategoryId = new Guid("67d3d048-b535-4fbc-aa59-b32f15ce25eb"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MANTENIMIENTO"
                        },
                        new
                        {
                            CategoryId = new Guid("69cf658f-1e02-4abc-9292-a9b65cac9c87"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "REPARACION"
                        });
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Condominium", b =>
                {
                    b.Property<Guid>("CondominiumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CondominiumId");

                    b.HasIndex("AccountId");

                    b.ToTable("Condominia");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Expense", b =>
                {
                    b.Property<Guid>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid?>("AttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CondominiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("PayeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ExpenseId");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CondominiumId");

                    b.HasIndex("PayeeId");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Fee", b =>
                {
                    b.Property<Guid>("FeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid?>("CondominiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeeId");

                    b.HasIndex("CondominiumId");

                    b.ToTable("Fees");

                    b.HasData(
                        new
                        {
                            FeeId = new Guid("c25383b7-35c8-445e-ab14-b13227de05a3"),
                            Amount = 5000.0,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateBegin = new DateTime(2021, 8, 5, 16, 26, 56, 94, DateTimeKind.Local).AddTicks(6205),
                            Name = "CUOTA"
                        });
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Income", b =>
                {
                    b.Property<Guid>("IncomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid?>("AttachmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CondominiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<Guid>("FeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UnitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IncomeId");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("CondominiumId");

                    b.HasIndex("FeeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Message", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CondominiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId");

                    b.HasIndex("CondominiumId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Minute", b =>
                {
                    b.Property<Guid>("MinuteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CondominiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("MinuteId");

                    b.HasIndex("CondominiumId");

                    b.ToTable("Minutes");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Owner", b =>
                {
                    b.Property<Guid>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CondominiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("OwnerId");

                    b.HasIndex("CondominiumId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Payee", b =>
                {
                    b.Property<Guid>("PayeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PayeeId");

                    b.HasIndex("AccountId");

                    b.ToTable("Payees");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("PaymentMethodId");

                    b.ToTable("PaymentMethods");

                    b.HasData(
                        new
                        {
                            PaymentMethodId = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "TARJETA DE CREDITO"
                        },
                        new
                        {
                            PaymentMethodId = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "CHEQUE"
                        },
                        new
                        {
                            PaymentMethodId = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "EFECTIVO"
                        },
                        new
                        {
                            PaymentMethodId = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "TRANSFERENCIA"
                        });
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Unit", b =>
                {
                    b.Property<Guid>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondominiumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UnitId");

                    b.HasIndex("CondominiumId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Bank", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Account", "Account")
                        .WithMany("Banks")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Category", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Account", "Account")
                        .WithMany("Categories")
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Condominium", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Account", "Account")
                        .WithMany("Condominia")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Expense", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId");

                    b.HasOne("OfiCondo.Management.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("OfiCondo.Management.Domain.Entities.Condominium", "Condominium")
                        .WithMany("Expenses")
                        .HasForeignKey("CondominiumId");

                    b.HasOne("OfiCondo.Management.Domain.Entities.Payee", "Payee")
                        .WithMany()
                        .HasForeignKey("PayeeId");

                    b.HasOne("OfiCondo.Management.Domain.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId");

                    b.Navigation("Attachment");

                    b.Navigation("Category");

                    b.Navigation("Condominium");

                    b.Navigation("Payee");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Fee", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Condominium", "Condominium")
                        .WithMany("Fees")
                        .HasForeignKey("CondominiumId");

                    b.Navigation("Condominium");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Income", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Attachment", "Attachment")
                        .WithMany()
                        .HasForeignKey("AttachmentId");

                    b.HasOne("OfiCondo.Management.Domain.Entities.Condominium", "Condominium")
                        .WithMany("Incomes")
                        .HasForeignKey("CondominiumId");

                    b.HasOne("OfiCondo.Management.Domain.Entities.Fee", "Fee")
                        .WithMany()
                        .HasForeignKey("FeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OfiCondo.Management.Domain.Entities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Attachment");

                    b.Navigation("Condominium");

                    b.Navigation("Fee");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Message", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Condominium", "Condominium")
                        .WithMany("Messages")
                        .HasForeignKey("CondominiumId");

                    b.Navigation("Condominium");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Minute", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Condominium", "Condominium")
                        .WithMany("Minutes")
                        .HasForeignKey("CondominiumId");

                    b.Navigation("Condominium");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Owner", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Condominium", "Condominium")
                        .WithMany()
                        .HasForeignKey("CondominiumId");

                    b.Navigation("Condominium");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Payee", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Unit", b =>
                {
                    b.HasOne("OfiCondo.Management.Domain.Entities.Condominium", "Condominium")
                        .WithMany("Units")
                        .HasForeignKey("CondominiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OfiCondo.Management.Domain.Entities.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Condominium");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Account", b =>
                {
                    b.Navigation("Banks");

                    b.Navigation("Categories");

                    b.Navigation("Condominia");
                });

            modelBuilder.Entity("OfiCondo.Management.Domain.Entities.Condominium", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Fees");

                    b.Navigation("Incomes");

                    b.Navigation("Messages");

                    b.Navigation("Minutes");

                    b.Navigation("Units");
                });
#pragma warning restore 612, 618
        }
    }
}