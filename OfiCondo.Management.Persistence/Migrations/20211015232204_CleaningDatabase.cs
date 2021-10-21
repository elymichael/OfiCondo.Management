using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfiCondo.Management.Persistence.Migrations
{
    public partial class CleaningDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("01770ab3-1ae2-46d1-bc8c-5f2d48f29c26"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("0bf4a844-1784-480f-b119-c6351c036e38"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("370d64f4-1d94-424e-859f-97e20541f538"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("67d3d048-b535-4fbc-aa59-b32f15ce25eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("69cf658f-1e02-4abc-9292-a9b65cac9c87"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("b2dcc802-3161-48be-8d91-94afbc460521"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("cdfb7d9f-bc03-41b3-b429-85e0d836da06"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("fe8bf415-ee05-4b43-a20a-418988ad49dc"));

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: new Guid("c25383b7-35c8-445e-ab14-b13227de05a3"));

            //migrationBuilder.AlterColumn<int>(
            //    name: "PaymentMethodId",
            //    table: "PaymentMethods",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "AccountId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("8ba73eb1-0e88-454b-b20e-fcdadf405195"), null, "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(65), null, null, "NOMINA" },
                    { new Guid("b5fb81fe-d640-4101-89cd-ba6faf6463d4"), null, "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(408), null, null, "GASTO GENERAL" },
                    { new Guid("841ddd4e-23b1-4fc4-b8dd-bb19f1286350"), null, "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(459), null, null, "GAS" },
                    { new Guid("aab5b9d3-e97e-4f7b-932f-5f345476d88d"), null, "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(489), null, null, "ENERGIA ELECTRICA" },
                    { new Guid("f1248f07-8a7a-4a93-a028-7e64baffa8a9"), null, "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(517), null, null, "AGUA" },
                    { new Guid("e95b79fa-08a0-48fa-a896-40fe58ebcd6d"), null, "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(550), null, null, "LIMPIEZA" },
                    { new Guid("d9bb58bc-d171-42ef-9c81-6de0ff5c83fa"), null, "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(596), null, null, "MANTENIMIENTO" },
                    { new Guid("07e593fe-3623-446a-aab6-725433d7b5e7"), null, "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(624), null, null, "REPARACION" }
                });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "FeeId", "Amount", "CondominiumId", "CreatedBy", "CreatedDate", "DateBegin", "DateEnd", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("29371840-82f8-4e77-b8bc-0d344b7dfb10"), 5000.0, null, "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(5891), new DateTime(2021, 10, 15, 19, 22, 2, 965, DateTimeKind.Local).AddTicks(5051), null, null, null, "CUOTA" });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 961, DateTimeKind.Local).AddTicks(342) });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 963, DateTimeKind.Local).AddTicks(9799) });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 963, DateTimeKind.Local).AddTicks(9992) });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { "Admin", new DateTime(2021, 10, 15, 19, 22, 2, 964, DateTimeKind.Local).AddTicks(28) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("07e593fe-3623-446a-aab6-725433d7b5e7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("841ddd4e-23b1-4fc4-b8dd-bb19f1286350"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("8ba73eb1-0e88-454b-b20e-fcdadf405195"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("aab5b9d3-e97e-4f7b-932f-5f345476d88d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("b5fb81fe-d640-4101-89cd-ba6faf6463d4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("d9bb58bc-d171-42ef-9c81-6de0ff5c83fa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("e95b79fa-08a0-48fa-a896-40fe58ebcd6d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("f1248f07-8a7a-4a93-a028-7e64baffa8a9"));

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "FeeId",
                keyValue: new Guid("29371840-82f8-4e77-b8bc-0d344b7dfb10"));

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethodId",
                table: "PaymentMethods",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "AccountId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("01770ab3-1ae2-46d1-bc8c-5f2d48f29c26"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "NOMINA" },
                    { new Guid("cdfb7d9f-bc03-41b3-b429-85e0d836da06"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "GASTO GENERAL" },
                    { new Guid("fe8bf415-ee05-4b43-a20a-418988ad49dc"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "GAS" },
                    { new Guid("b2dcc802-3161-48be-8d91-94afbc460521"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "ENERGIA ELECTRICA" },
                    { new Guid("370d64f4-1d94-424e-859f-97e20541f538"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AGUA" },
                    { new Guid("0bf4a844-1784-480f-b119-c6351c036e38"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "LIMPIEZA" },
                    { new Guid("67d3d048-b535-4fbc-aa59-b32f15ce25eb"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "MANTENIMIENTO" },
                    { new Guid("69cf658f-1e02-4abc-9292-a9b65cac9c87"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "REPARACION" }
                });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "FeeId", "Amount", "CondominiumId", "CreatedBy", "CreatedDate", "DateBegin", "DateEnd", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("c25383b7-35c8-445e-ab14-b13227de05a3"), 5000.0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 5, 16, 26, 56, 94, DateTimeKind.Local).AddTicks(6205), null, null, null, "CUOTA" });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedDate" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
