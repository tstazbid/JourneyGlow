using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JourneyGlow.Migrations.AuthDB
{
    /// <inheritdoc />
    public partial class addingauthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abd0f94f-53ed-4185-a916-c7e72c1fdca6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32c41ac3-4508-4b6b-b094-17d168d651df", "AQAAAAIAAYagAAAAEO0XWN9zCzUG8UVHZT07PEtF77zfjvv+Bzl3xnjieb5/AE/uvVFJnWOkNlDjwAhZQQ==", "25f198ec-fa4d-44d1-babe-7cf5b22c5db0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abd0f94f-53ed-4185-a916-c7e72c1fdca6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73e4dcdf-2480-4aa4-8210-7994975f9459", "AQAAAAIAAYagAAAAEPU9a/5xU+pX9UYyE8zxftfYN9ler7mp32l/aVJJE1k0lCcMO4lRmQZ3g/7e8GfwBQ==", "03bcd7a3-42d6-413d-8b3a-0071f1cfdc34" });
        }
    }
}
