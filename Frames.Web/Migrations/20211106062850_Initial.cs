using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frames.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    LastMonthBill = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    LastMonthLeft = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminBills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminFramesIns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfFrames = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminFramesIns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminFramesOuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminFramesOuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    WorkerPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkerPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminBillFrameTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrameName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrameRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AdminBillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminBillFrameTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminBillFrameTypes_AdminBills_AdminBillId",
                        column: x => x.AdminBillId,
                        principalTable: "AdminBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminFramesOutNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfFrames = table.Column<int>(type: "int", nullable: false),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    AdminFramesOutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminFramesOutNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminFramesOutNumbers_AdminFramesOuts_AdminFramesOutId",
                        column: x => x.AdminFramesOutId,
                        principalTable: "AdminFramesOuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminFramesOutNumbers_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cleared = table.Column<bool>(type: "bit", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerBills_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerFramesIns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfFrames = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerFramesIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerFramesIns_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerFramesOuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerFramesOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerFramesOuts_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerBillFrameTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrameName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrameRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    WorkerBillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerBillFrameTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerBillFrameTypes_WorkerBills_WorkerBillId",
                        column: x => x.WorkerBillId,
                        principalTable: "WorkerBills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerFramesOutNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfFrames = table.Column<int>(type: "int", nullable: false),
                    WorkerFramesOutId = table.Column<int>(type: "int", nullable: false),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerFramesOutNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerFramesOutNumbers_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerFramesOutNumbers_WorkerFramesOuts_WorkerFramesOutId",
                        column: x => x.WorkerFramesOutId,
                        principalTable: "WorkerFramesOuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminBillFrameTypes_AdminBillId",
                table: "AdminBillFrameTypes",
                column: "AdminBillId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminFramesOutNumbers_AdminFramesOutId",
                table: "AdminFramesOutNumbers",
                column: "AdminFramesOutId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminFramesOutNumbers_ItemTypeId",
                table: "AdminFramesOutNumbers",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerBillFrameTypes_WorkerBillId",
                table: "WorkerBillFrameTypes",
                column: "WorkerBillId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerBills_WorkerId",
                table: "WorkerBills",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerFramesIns_WorkerId",
                table: "WorkerFramesIns",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerFramesOutNumbers_ItemTypeId",
                table: "WorkerFramesOutNumbers",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerFramesOutNumbers_WorkerFramesOutId",
                table: "WorkerFramesOutNumbers",
                column: "WorkerFramesOutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerFramesOuts_WorkerId",
                table: "WorkerFramesOuts",
                column: "WorkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminBillFrameTypes");

            migrationBuilder.DropTable(
                name: "AdminFramesIns");

            migrationBuilder.DropTable(
                name: "AdminFramesOutNumbers");

            migrationBuilder.DropTable(
                name: "AdminPayments");

            migrationBuilder.DropTable(
                name: "WorkerBillFrameTypes");

            migrationBuilder.DropTable(
                name: "WorkerFramesIns");

            migrationBuilder.DropTable(
                name: "WorkerFramesOutNumbers");

            migrationBuilder.DropTable(
                name: "WorkerPayments");

            migrationBuilder.DropTable(
                name: "AdminBills");

            migrationBuilder.DropTable(
                name: "AdminFramesOuts");

            migrationBuilder.DropTable(
                name: "WorkerBills");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "WorkerFramesOuts");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
