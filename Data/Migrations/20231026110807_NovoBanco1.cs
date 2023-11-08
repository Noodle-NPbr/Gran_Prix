using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gran_Prix.Data.Migrations
{
    public partial class NovoBanco1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "funcionario");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "funcionario");

            migrationBuilder.DropColumn(
                name: "N_Casa",
                table: "funcionario");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "funcionario");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "N_Casa",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "clientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "funcionario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "N_Casa",
                table: "funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "N_Casa",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
