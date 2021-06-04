﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201229215226_WebMigration")]
    partial class WebMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Domain.BoardState", b =>
                {
                    b.Property<int>("BoardStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PlayerBoardState")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("BoardStateId");

                    b.HasIndex("PlayerId");

                    b.ToTable("BoardState");
                });

            modelBuilder.Entity("Domain.Boat", b =>
                {
                    b.Property<int>("BoatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("BoatId");

                    b.ToTable("Boats");
                });

            modelBuilder.Entity("Domain.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("GameOptionId")
                        .HasColumnType("int");

                    b.Property<string>("History")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Player1BoardStateId")
                        .HasColumnType("int");

                    b.Property<int>("Player1Id")
                        .HasColumnType("int");

                    b.Property<int>("Player2BoardStateId")
                        .HasColumnType("int");

                    b.Property<int>("Player2Id")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("GameOptionId");

                    b.HasIndex("Player1BoardStateId");

                    b.HasIndex("Player1Id");

                    b.HasIndex("Player2BoardStateId");

                    b.HasIndex("Player2Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Domain.GameOption", b =>
                {
                    b.Property<int>("GameOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EBoatsCanTouch")
                        .HasColumnType("int");

                    b.Property<int>("ENextMoveAfterHit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("GameOptionId");

                    b.ToTable("GameOptions");
                });

            modelBuilder.Entity("Domain.GameOptionBoat", b =>
                {
                    b.Property<int>("GameOptionBoatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BoatId")
                        .HasColumnType("int");

                    b.Property<int>("GameOptionId")
                        .HasColumnType("int");

                    b.HasKey("GameOptionBoatId");

                    b.HasIndex("BoatId");

                    b.HasIndex("GameOptionId");

                    b.ToTable("GameOptionBoats");
                });

            modelBuilder.Entity("Domain.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("EPlayerType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("PlayerTurn")
                        .HasColumnType("bit");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Domain.BoardState", b =>
                {
                    b.HasOne("Domain.Player", "Player")
                        .WithMany("BoardStates")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Domain.Game", b =>
                {
                    b.HasOne("Domain.GameOption", "GameOption")
                        .WithMany("Games")
                        .HasForeignKey("GameOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.BoardState", "Player1BoardState")
                        .WithMany("Games1")
                        .HasForeignKey("Player1BoardStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Player", "Player1")
                        .WithMany("Player1Games")
                        .HasForeignKey("Player1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.BoardState", "Player2BoardState")
                        .WithMany("Games2")
                        .HasForeignKey("Player2BoardStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Player", "Player2")
                        .WithMany("Player2Games")
                        .HasForeignKey("Player2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GameOption");

                    b.Navigation("Player1");

                    b.Navigation("Player1BoardState");

                    b.Navigation("Player2");

                    b.Navigation("Player2BoardState");
                });

            modelBuilder.Entity("Domain.GameOptionBoat", b =>
                {
                    b.HasOne("Domain.Boat", "Boat")
                        .WithMany("GameOptionBoats")
                        .HasForeignKey("BoatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.GameOption", "GameOption")
                        .WithMany("GameOptionBoats")
                        .HasForeignKey("GameOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Boat");

                    b.Navigation("GameOption");
                });

            modelBuilder.Entity("Domain.BoardState", b =>
                {
                    b.Navigation("Games1");

                    b.Navigation("Games2");
                });

            modelBuilder.Entity("Domain.Boat", b =>
                {
                    b.Navigation("GameOptionBoats");
                });

            modelBuilder.Entity("Domain.GameOption", b =>
                {
                    b.Navigation("GameOptionBoats");

                    b.Navigation("Games");
                });

            modelBuilder.Entity("Domain.Player", b =>
                {
                    b.Navigation("BoardStates");

                    b.Navigation("Player1Games");

                    b.Navigation("Player2Games");
                });
#pragma warning restore 612, 618
        }
    }
}
