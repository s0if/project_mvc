using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Landing.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ce1c71c-87e9-4207-951f-4badea8c2bc9", null, "superAdmin", "SUPERADMIN" },
                    { "9fdd0a3e-9d26-4666-b673-8f8d661c610c", null, "Admin", "ADMIN" },
                    { "c69df710-04de-478c-878e-14d54053ac35", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "16cea396-5e1a-4d21-982d-79519d744235", 0, null, "fdc326c4-388f-4a5e-8ffa-9a3628d3dcea", "admin@gmail.com", false, null, null, false, null, "ADMIN@GMAIL.COM", "ADMMIN@GMAIL.COM", "AQAAAAIAAYagAAAAENGVSfhmgUV8tbkN0BkhJS5gZEksy6OTSb1AnHpJ5nHfF+1jnG7VUPcL9kp+JDUgog==", null, false, "22bf0557-5650-4c24-a0a6-83af6a366587", false, "admin@gmail.com" },
                    { "6f801f02-1def-4d49-b4a9-2919568d9f9f", 0, null, "91eae0f5-0b54-4ca0-8762-b5a8ef550386", "User@gmail.com", false, null, null, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAIAAYagAAAAEAA7re+THIaAux766sQB5XRsuKop/nm1910p2LDBtUHvRsuhxlguxJLqEMagB+XI2A==", null, false, "c7b3b073-7275-45de-9d29-7a9077c034ce", false, "User@gmail.com" },
                    { "93f82c5c-3a2c-434d-b4d0-76aa79c7ac26", 0, null, "93910c9d-23e5-4d0f-b5cc-8342f668db49", "superadmin@gmail.com", false, null, null, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEFccVg3CPWQZ1YBofJk8gNyQn5WLQBdW+Pgtp1b3ZaPqfYULH+u9MLa/JDE5sbKGiA==", null, false, "b96f429f-475f-45f1-aa5f-2479d4cbec7e", false, "superadmin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9fdd0a3e-9d26-4666-b673-8f8d661c610c", "16cea396-5e1a-4d21-982d-79519d744235" },
                    { "c69df710-04de-478c-878e-14d54053ac35", "6f801f02-1def-4d49-b4a9-2919568d9f9f" },
                    { "3ce1c71c-87e9-4207-951f-4badea8c2bc9", "93f82c5c-3a2c-434d-b4d0-76aa79c7ac26" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9fdd0a3e-9d26-4666-b673-8f8d661c610c", "16cea396-5e1a-4d21-982d-79519d744235" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c69df710-04de-478c-878e-14d54053ac35", "6f801f02-1def-4d49-b4a9-2919568d9f9f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3ce1c71c-87e9-4207-951f-4badea8c2bc9", "93f82c5c-3a2c-434d-b4d0-76aa79c7ac26" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ce1c71c-87e9-4207-951f-4badea8c2bc9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fdd0a3e-9d26-4666-b673-8f8d661c610c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c69df710-04de-478c-878e-14d54053ac35");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16cea396-5e1a-4d21-982d-79519d744235");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f801f02-1def-4d49-b4a9-2919568d9f9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93f82c5c-3a2c-434d-b4d0-76aa79c7ac26");
        }
    }
}
