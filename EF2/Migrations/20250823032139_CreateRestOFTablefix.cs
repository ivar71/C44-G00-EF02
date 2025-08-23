using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF2.Migrations
{
    /// <inheritdoc />
    public partial class CreateRestOFTablefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HiringDate",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "22/11/2004");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HiringDate",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "22/11/2004",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
