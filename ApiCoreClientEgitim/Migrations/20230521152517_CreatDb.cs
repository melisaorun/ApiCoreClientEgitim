using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCoreClientEgitim.Migrations
{
    public partial class CreatDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Egitmenler",
                columns: table => new
                {
                    EgitmenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitmenler", x => x.EgitmenId);
                });

            migrationBuilder.CreateTable(
                name: "Katilimcilar",
                columns: table => new
                {
                    KatilimciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katilimcilar", x => x.KatilimciId);
                });

            migrationBuilder.CreateTable(
                name: "Kurslar",
                columns: table => new
                {
                    KursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KursAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KursSuresi = table.Column<int>(type: "int", nullable: false),
                    KursUcreti = table.Column<int>(type: "int", nullable: false),
                    EgitimenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurslar", x => x.KursId);
                    table.ForeignKey(
                        name: "FK_Kurslar_Egitmenler_EgitimenId",
                        column: x => x.EgitimenId,
                        principalTable: "Egitmenler",
                        principalColumn: "EgitmenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KursKatilim",
                columns: table => new
                {
                    KursKatilimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaslangicTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BitisTarihi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    KatilimciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursKatilim", x => x.KursKatilimId);
                    table.ForeignKey(
                        name: "FK_KursKatilim_Katilimcilar_KatilimciId",
                        column: x => x.KatilimciId,
                        principalTable: "Katilimcilar",
                        principalColumn: "KatilimciId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursKatilim_Kurslar_KursId",
                        column: x => x.KursId,
                        principalTable: "Kurslar",
                        principalColumn: "KursId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KursKatilim_KatilimciId",
                table: "KursKatilim",
                column: "KatilimciId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKatilim_KursId",
                table: "KursKatilim",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurslar_EgitimenId",
                table: "Kurslar",
                column: "EgitimenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KursKatilim");

            migrationBuilder.DropTable(
                name: "Katilimcilar");

            migrationBuilder.DropTable(
                name: "Kurslar");

            migrationBuilder.DropTable(
                name: "Egitmenler");
        }
    }
}
