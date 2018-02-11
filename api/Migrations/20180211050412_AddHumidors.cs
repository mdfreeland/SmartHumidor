using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace api.Migrations
{
    public partial class AddHumidors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "given_name",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "humidors",
                columns: table => new
                {
                    humidor_id = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    application_user_id = table.Column<string>(type: "text", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_humidors", x => x.humidor_id);
                    table.ForeignKey(
                        name: "fk_humidors_users_application_user_id",
                        column: x => x.application_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hygrometers",
                columns: table => new
                {
                    hygrometer_id = table.Column<long>(type: "int8", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    device_id = table.Column<string>(type: "text", nullable: true),
                    humidor_id = table.Column<long>(type: "int8", nullable: true),
                    label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hygrometers", x => x.hygrometer_id);
                    table.ForeignKey(
                        name: "fk_hygrometers_humidors_humidor_id",
                        column: x => x.humidor_id,
                        principalTable: "humidors",
                        principalColumn: "humidor_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_humidors_application_user_id",
                table: "humidors",
                column: "application_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_hygrometers_humidor_id",
                table: "hygrometers",
                column: "humidor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hygrometers");

            migrationBuilder.DropTable(
                name: "humidors");

            migrationBuilder.DropColumn(
                name: "first_name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "given_name",
                table: "users",
                nullable: true);
        }
    }
}
