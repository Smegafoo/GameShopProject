﻿// <auto-generated />
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Concrete.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdminLevel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Entities.Concrete.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GameDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GameGenre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GamePrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Entities.Concrete.GameLibrary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameNumber")
                        .HasColumnType("int");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("gameLibraries");
                });

            modelBuilder.Entity("Entities.Concrete.GameReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ReviewPoint")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GameReviews");
                });

            modelBuilder.Entity("Entities.Concrete.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameLibraryId")
                        .HasColumnType("int");

                    b.Property<string>("PlayerDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Entities.Relation.LibraryGames", b =>
                {
                    b.Property<int>("GameLibraryId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("GameLibraryId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("LibraryGames");
                });

            modelBuilder.Entity("GameGameLibrary", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("LibrariesId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "LibrariesId");

                    b.HasIndex("LibrariesId");

                    b.ToTable("GameGameLibrary");
                });

            modelBuilder.Entity("Entities.Relation.LibraryGames", b =>
                {
                    b.HasOne("Entities.Concrete.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.GameLibrary", "Library")
                        .WithMany()
                        .HasForeignKey("GameLibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("GameGameLibrary", b =>
                {
                    b.HasOne("Entities.Concrete.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.GameLibrary", null)
                        .WithMany()
                        .HasForeignKey("LibrariesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
