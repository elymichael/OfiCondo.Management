using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfiCondo.Management.Persistence.Migrations
{
    public partial class ChangingInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Condominia_CondominiumId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Owners_OwnerId",
                table: "Units");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("53824292-1de2-460b-af8a-70413650c128"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c75934eb-5d3c-4dd7-be2b-54527e7096f1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Units",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CondominiumId",
                table: "Fees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Condominia_CondominiumId",
                table: "Fees",
                column: "CondominiumId",
                principalTable: "Condominia",
                principalColumn: "CondominiumId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Owners_OwnerId",
                table: "Units",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fees_Condominia_CondominiumId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Owners_OwnerId",
                table: "Units");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Units",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CondominiumId",
                table: "Fees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "AccountId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("53824292-1de2-460b-af8a-70413650c128"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "NOMINA" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "AccountId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("c75934eb-5d3c-4dd7-be2b-54527e7096f1"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "GENERAL" });

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_Condominia_CondominiumId",
                table: "Fees",
                column: "CondominiumId",
                principalTable: "Condominia",
                principalColumn: "CondominiumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Owners_OwnerId",
                table: "Units",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
