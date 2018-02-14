using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace api.Migrations
{
    public partial class AddHumidorChildForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_hygrometers_humidors_humidor_id",
                table: "hygrometers");

            migrationBuilder.AlterColumn<long>(
                name: "humidor_id",
                table: "hygrometers",
                type: "int8",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_hygrometers_humidors_humidor_id",
                table: "hygrometers",
                column: "humidor_id",
                principalTable: "humidors",
                principalColumn: "humidor_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_hygrometers_humidors_humidor_id",
                table: "hygrometers");

            migrationBuilder.AlterColumn<long>(
                name: "humidor_id",
                table: "hygrometers",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "int8");

            migrationBuilder.AddForeignKey(
                name: "fk_hygrometers_humidors_humidor_id",
                table: "hygrometers",
                column: "humidor_id",
                principalTable: "humidors",
                principalColumn: "humidor_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
