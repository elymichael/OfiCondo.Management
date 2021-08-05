using Microsoft.EntityFrameworkCore.Migrations;

namespace OfiCondo.Management.Identity.Migrations
{
    public partial class ChangingInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f4271e1a-dbd2-4c53-abee-42d4afa3f9df", "3916163a-008c-4b2f-9219-3164e5ba55e4", "Admin", "ADMIN" },
                    { "cfb047cb-8a5d-48a1-ae3e-e8f25ae65bdc", "771df3e8-ac7e-4472-9f88-15832fecbe94", "Developer", "DEVELOPER" },
                    { "4ddbac95-fb56-4452-99aa-70d5541f7fe0", "06c6e61f-89af-4df1-ba0e-41d0d4830fae", "Owner", "OWNER" },
                    { "5cc323aa-58df-4abc-b0e8-a72addc1f1e5", "ec21191f-95c7-43d0-bef2-0bc8ed6cd800", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dd35d405-558e-4dcf-80a6-c39f070447a1", 0, "701c1df0-94c7-4e9d-8fc6-51682bfbde00", "elymichael@sitcsrd.com", true, "Admin", "Admin", false, null, "ELYMICHAEL@SITCSRD.COM", "ADMINISTRADOR", "AQAAAAEAACcQAAAAEBYwdAdw5d36mLi4lT7uya7ckUz4oNmPqbaGaLtaEje/1j+nu4cV7kEEq0zi6O86fQ==", null, false, "", false, "administrador" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f4271e1a-dbd2-4c53-abee-42d4afa3f9df", "dd35d405-558e-4dcf-80a6-c39f070447a1" },
                    { "cfb047cb-8a5d-48a1-ae3e-e8f25ae65bdc", "dd35d405-558e-4dcf-80a6-c39f070447a1" },
                    { "4ddbac95-fb56-4452-99aa-70d5541f7fe0", "dd35d405-558e-4dcf-80a6-c39f070447a1" },
                    { "5cc323aa-58df-4abc-b0e8-a72addc1f1e5", "dd35d405-558e-4dcf-80a6-c39f070447a1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ddbac95-fb56-4452-99aa-70d5541f7fe0", "dd35d405-558e-4dcf-80a6-c39f070447a1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5cc323aa-58df-4abc-b0e8-a72addc1f1e5", "dd35d405-558e-4dcf-80a6-c39f070447a1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cfb047cb-8a5d-48a1-ae3e-e8f25ae65bdc", "dd35d405-558e-4dcf-80a6-c39f070447a1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f4271e1a-dbd2-4c53-abee-42d4afa3f9df", "dd35d405-558e-4dcf-80a6-c39f070447a1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ddbac95-fb56-4452-99aa-70d5541f7fe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cc323aa-58df-4abc-b0e8-a72addc1f1e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfb047cb-8a5d-48a1-ae3e-e8f25ae65bdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4271e1a-dbd2-4c53-abee-42d4afa3f9df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dd35d405-558e-4dcf-80a6-c39f070447a1");
        }
    }
}
