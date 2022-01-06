using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiaoVien",
                columns: table => new
                {
                    MaGV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoVien", x => x.MaGV);
                });

            migrationBuilder.CreateTable(
                name: "KhoaThi",
                columns: table => new
                {
                    MaKhoaThi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhoaThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayThi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaThi", x => x.MaKhoaThi);
                });

            migrationBuilder.CreateTable(
                name: "ThiSinh",
                columns: table => new
                {
                    CMND = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiSinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayCap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThiSinh", x => x.CMND);
                });

            migrationBuilder.CreateTable(
                name: "TrinhDo",
                columns: table => new
                {
                    MaTrinhDo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTrinhDo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrinhDo", x => x.MaTrinhDo);
                });

            migrationBuilder.CreateTable(
                name: "PhongThi",
                columns: table => new
                {
                    MaPhongThi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTrinhDo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaKhoaThi = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongThi", x => x.MaPhongThi);
                    table.ForeignKey(
                        name: "FK_PhongThi_KhoaThi_MaKhoaThi",
                        column: x => x.MaKhoaThi,
                        principalTable: "KhoaThi",
                        principalColumn: "MaKhoaThi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhongThi_TrinhDo_MaTrinhDo",
                        column: x => x.MaTrinhDo,
                        principalTable: "TrinhDo",
                        principalColumn: "MaTrinhDo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoBaoDanh",
                columns: table => new
                {
                    SBD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaKhoaThi = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaTrinhDo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoBaoDanh", x => x.SBD);
                    table.ForeignKey(
                        name: "FK_SoBaoDanh_KhoaThi_MaKhoaThi",
                        column: x => x.MaKhoaThi,
                        principalTable: "KhoaThi",
                        principalColumn: "MaKhoaThi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoBaoDanh_ThiSinh_CMND",
                        column: x => x.CMND,
                        principalTable: "ThiSinh",
                        principalColumn: "CMND",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoBaoDanh_TrinhDo_MaTrinhDo",
                        column: x => x.MaTrinhDo,
                        principalTable: "TrinhDo",
                        principalColumn: "MaTrinhDo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CanhThi",
                columns: table => new
                {
                    MaGV = table.Column<int>(type: "int", nullable: false),
                    MaPhongThi = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanhThi", x => new { x.MaGV, x.MaPhongThi });
                    table.ForeignKey(
                        name: "FK_CanhThi_GiaoVien_MaGV",
                        column: x => x.MaGV,
                        principalTable: "GiaoVien",
                        principalColumn: "MaGV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CanhThi_PhongThi_MaPhongThi",
                        column: x => x.MaPhongThi,
                        principalTable: "PhongThi",
                        principalColumn: "MaPhongThi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThamGiaDuThi",
                columns: table => new
                {
                    SBD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaPhongThi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nghe = table.Column<int>(type: "int", nullable: true),
                    Noi = table.Column<int>(type: "int", nullable: true),
                    Doc = table.Column<int>(type: "int", nullable: true),
                    Viet = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThamGiaDuThi", x => new { x.SBD, x.MaPhongThi });
                    table.ForeignKey(
                        name: "FK_ThamGiaDuThi_PhongThi_MaPhongThi",
                        column: x => x.MaPhongThi,
                        principalTable: "PhongThi",
                        principalColumn: "MaPhongThi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThamGiaDuThi_SoBaoDanh_SBD",
                        column: x => x.SBD,
                        principalTable: "SoBaoDanh",
                        principalColumn: "SBD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GiaoVien",
                columns: new[] { "MaGV", "Email", "GioiTinh", "HoTen", "NgaySinh", "SDT" },
                values: new object[,]
                {
                    { 1, "nhung22@gmail.com", 1, "Ngô Ngọc Nhung", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0942810024" },
                    { 2, "dund@gmail.com", 0, "Hồ Tấn Dũng", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0378240942" }
                });

            migrationBuilder.InsertData(
                table: "KhoaThi",
                columns: new[] { "MaKhoaThi", "NgayThi", "TenKhoaThi" },
                values: new object[] { "KT2251", new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "KT2251" });

            migrationBuilder.InsertData(
                table: "ThiSinh",
                columns: new[] { "CMND", "Email", "GioiTinh", "HoTen", "NgayCap", "NgaySinh", "NoiCap", "NoiSinh", "SDT" },
                values: new object[] { "231852123", "truongdatnhan@gmail.com", 0, "Trương Đạt Nhân", new DateTime(2016, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ninh Thuận", "Ninh Thuận", null });

            migrationBuilder.InsertData(
                table: "TrinhDo",
                columns: new[] { "MaTrinhDo", "TenTrinhDo" },
                values: new object[,]
                {
                    { "A2", "A2" },
                    { "B1", "B1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanhThi_MaPhongThi",
                table: "CanhThi",
                column: "MaPhongThi");

            migrationBuilder.CreateIndex(
                name: "IX_PhongThi_MaKhoaThi",
                table: "PhongThi",
                column: "MaKhoaThi");

            migrationBuilder.CreateIndex(
                name: "IX_PhongThi_MaTrinhDo",
                table: "PhongThi",
                column: "MaTrinhDo");

            migrationBuilder.CreateIndex(
                name: "IX_SoBaoDanh_CMND",
                table: "SoBaoDanh",
                column: "CMND",
                unique: true,
                filter: "[CMND] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SoBaoDanh_MaKhoaThi",
                table: "SoBaoDanh",
                column: "MaKhoaThi");

            migrationBuilder.CreateIndex(
                name: "IX_SoBaoDanh_MaTrinhDo",
                table: "SoBaoDanh",
                column: "MaTrinhDo");

            migrationBuilder.CreateIndex(
                name: "IX_ThamGiaDuThi_MaPhongThi",
                table: "ThamGiaDuThi",
                column: "MaPhongThi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanhThi");

            migrationBuilder.DropTable(
                name: "ThamGiaDuThi");

            migrationBuilder.DropTable(
                name: "GiaoVien");

            migrationBuilder.DropTable(
                name: "PhongThi");

            migrationBuilder.DropTable(
                name: "SoBaoDanh");

            migrationBuilder.DropTable(
                name: "KhoaThi");

            migrationBuilder.DropTable(
                name: "ThiSinh");

            migrationBuilder.DropTable(
                name: "TrinhDo");
        }
    }
}
