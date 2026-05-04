using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncBreakfastMVC.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breakfasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    ActionData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breakfasts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bacons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    BreakfastId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bacons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bacons_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coffees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    BreakfastId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coffees_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eggs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    BreakfastId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eggs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eggs_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Juices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    BreakfastId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Juices_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Toasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    HasJam = table.Column<bool>(nullable: false),
                    HasButter = table.Column<bool>(nullable: false),
                    BreakfastId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toasts_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bacons_BreakfastId",
                table: "Bacons",
                column: "BreakfastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breakfasts_OrderId",
                table: "Breakfasts",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coffees_BreakfastId",
                table: "Coffees",
                column: "BreakfastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eggs_BreakfastId",
                table: "Eggs",
                column: "BreakfastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Juices_BreakfastId",
                table: "Juices",
                column: "BreakfastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toasts_BreakfastId",
                table: "Toasts",
                column: "BreakfastId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bacons");

            migrationBuilder.DropTable(
                name: "Coffees");

            migrationBuilder.DropTable(
                name: "Eggs");

            migrationBuilder.DropTable(
                name: "Juices");

            migrationBuilder.DropTable(
                name: "Toasts");

            migrationBuilder.DropTable(
                name: "Breakfasts");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
