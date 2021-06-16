using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace heroesCompanyAngular.Data.Migrations
{
    public partial class heromodelandcontextadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAttacker = table.Column<bool>(type: "bit", nullable: false),
                    InitialTrainDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuitColor = table.Column<int>(type: "int", nullable: false),
                    StartingPower = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentPower = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrainedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainedCount = table.Column<byte>(type: "tinyint", nullable: false),
                    TrainerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_AspNetUsers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_TrainerId",
                table: "Heroes",
                column: "TrainerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
