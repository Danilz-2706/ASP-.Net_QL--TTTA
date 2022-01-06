﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CenterContext))]
    partial class CenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.CanhThi", b =>
                {
                    b.Property<int>("MaGV")
                        .HasColumnType("int");

                    b.Property<string>("MaPhongThi")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaGV", "MaPhongThi");

                    b.HasIndex("MaPhongThi");

                    b.ToTable("CanhThi");
                });

            modelBuilder.Entity("Domain.Entities.GiaoVien", b =>
                {
                    b.Property<int>("MaGV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaGV");

                    b.ToTable("GiaoVien");

                    b.HasData(
                        new
                        {
                            MaGV = 1,
                            Email = "nhung22@gmail.com",
                            GioiTinh = 1,
                            HoTen = "Ngô Ngọc Nhung",
                            NgaySinh = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SDT = "0942810024"
                        },
                        new
                        {
                            MaGV = 2,
                            Email = "dund@gmail.com",
                            GioiTinh = 0,
                            HoTen = "Hồ Tấn Dũng",
                            NgaySinh = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SDT = "0378240942"
                        });
                });

            modelBuilder.Entity("Domain.Entities.KhoaThi", b =>
                {
                    b.Property<string>("MaKhoaThi")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayThi")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenKhoaThi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKhoaThi");

                    b.ToTable("KhoaThi");

                    b.HasData(
                        new
                        {
                            MaKhoaThi = "KT2251",
                            NgayThi = new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenKhoaThi = "KT2251"
                        });
                });

            modelBuilder.Entity("Domain.Entities.PhongThi", b =>
                {
                    b.Property<string>("MaPhongThi")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKhoaThi")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaTrinhDo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenPhong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("MaPhongThi");

                    b.HasIndex("MaKhoaThi");

                    b.HasIndex("MaTrinhDo");

                    b.ToTable("PhongThi");
                });

            modelBuilder.Entity("Domain.Entities.SoBaoDanh", b =>
                {
                    b.Property<string>("SBD")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CMND")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaKhoaThi")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaTrinhDo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SBD");

                    b.HasIndex("CMND")
                        .IsUnique()
                        .HasFilter("[CMND] IS NOT NULL");

                    b.HasIndex("MaKhoaThi");

                    b.HasIndex("MaTrinhDo");

                    b.ToTable("SoBaoDanh");
                });

            modelBuilder.Entity("Domain.Entities.ThamGiaDuThi", b =>
                {
                    b.Property<string>("SBD")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaPhongThi")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Doc")
                        .HasColumnType("int");

                    b.Property<int?>("Nghe")
                        .HasColumnType("int");

                    b.Property<int?>("Noi")
                        .HasColumnType("int");

                    b.Property<int?>("Viet")
                        .HasColumnType("int");

                    b.HasKey("SBD", "MaPhongThi");

                    b.HasIndex("MaPhongThi");

                    b.ToTable("ThamGiaDuThi");
                });

            modelBuilder.Entity("Domain.Entities.ThiSinh", b =>
                {
                    b.Property<string>("CMND")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayCap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiCap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoiSinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CMND");

                    b.ToTable("ThiSinh");

                    b.HasData(
                        new
                        {
                            CMND = "231852123",
                            Email = "truongdatnhan@gmail.com",
                            GioiTinh = 0,
                            HoTen = "Trương Đạt Nhân",
                            NgayCap = new DateTime(2016, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NgaySinh = new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoiCap = "Ninh Thuận",
                            NoiSinh = "Ninh Thuận"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TrinhDo", b =>
                {
                    b.Property<string>("MaTrinhDo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenTrinhDo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTrinhDo");

                    b.ToTable("TrinhDo");

                    b.HasData(
                        new
                        {
                            MaTrinhDo = "A2",
                            TenTrinhDo = "A2"
                        },
                        new
                        {
                            MaTrinhDo = "B1",
                            TenTrinhDo = "B1"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CanhThi", b =>
                {
                    b.HasOne("Domain.Entities.GiaoVien", "GiaoVien")
                        .WithMany("CanhThis")
                        .HasForeignKey("MaGV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.PhongThi", "PhongThi")
                        .WithMany("CanhThis")
                        .HasForeignKey("MaPhongThi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GiaoVien");

                    b.Navigation("PhongThi");
                });

            modelBuilder.Entity("Domain.Entities.PhongThi", b =>
                {
                    b.HasOne("Domain.Entities.KhoaThi", "KhoaThi")
                        .WithMany("PhongThis")
                        .HasForeignKey("MaKhoaThi");

                    b.HasOne("Domain.Entities.TrinhDo", "TrinhDo")
                        .WithMany("PhongThis")
                        .HasForeignKey("MaTrinhDo");

                    b.Navigation("KhoaThi");

                    b.Navigation("TrinhDo");
                });

            modelBuilder.Entity("Domain.Entities.SoBaoDanh", b =>
                {
                    b.HasOne("Domain.Entities.ThiSinh", "ThiSinh")
                        .WithOne("SBD")
                        .HasForeignKey("Domain.Entities.SoBaoDanh", "CMND");

                    b.HasOne("Domain.Entities.KhoaThi", "KhoaThi")
                        .WithMany("SBDs")
                        .HasForeignKey("MaKhoaThi");

                    b.HasOne("Domain.Entities.TrinhDo", "TrinhDo")
                        .WithMany("SBDs")
                        .HasForeignKey("MaTrinhDo");

                    b.Navigation("KhoaThi");

                    b.Navigation("ThiSinh");

                    b.Navigation("TrinhDo");
                });

            modelBuilder.Entity("Domain.Entities.ThamGiaDuThi", b =>
                {
                    b.HasOne("Domain.Entities.PhongThi", "PhongThi")
                        .WithMany("ThamGiaDuThis")
                        .HasForeignKey("MaPhongThi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.SoBaoDanh", "SoBaoDanh")
                        .WithMany("ThamGiaDuThis")
                        .HasForeignKey("SBD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhongThi");

                    b.Navigation("SoBaoDanh");
                });

            modelBuilder.Entity("Domain.Entities.GiaoVien", b =>
                {
                    b.Navigation("CanhThis");
                });

            modelBuilder.Entity("Domain.Entities.KhoaThi", b =>
                {
                    b.Navigation("PhongThis");

                    b.Navigation("SBDs");
                });

            modelBuilder.Entity("Domain.Entities.PhongThi", b =>
                {
                    b.Navigation("CanhThis");

                    b.Navigation("ThamGiaDuThis");
                });

            modelBuilder.Entity("Domain.Entities.SoBaoDanh", b =>
                {
                    b.Navigation("ThamGiaDuThis");
                });

            modelBuilder.Entity("Domain.Entities.ThiSinh", b =>
                {
                    b.Navigation("SBD");
                });

            modelBuilder.Entity("Domain.Entities.TrinhDo", b =>
                {
                    b.Navigation("PhongThis");

                    b.Navigation("SBDs");
                });
#pragma warning restore 612, 618
        }
    }
}
