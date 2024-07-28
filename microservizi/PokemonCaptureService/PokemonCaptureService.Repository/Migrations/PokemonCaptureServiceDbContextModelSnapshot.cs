﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonCaptureService.Repository;

#nullable disable

namespace PokemonCaptureService.Repository.Migrations
{
    [DbContext(typeof(PokemonCaptureServiceDbContext))]
    partial class PokemonCaptureServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokemonCaptureService.Repository.Model.Items", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("ItemId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("PokemonCaptureService.Repository.Model.Pokemon", b =>
                {
                    b.Property<int>("PokemonId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("PokemonImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "img");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.HasKey("PokemonId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonCaptureService.Repository.Model.TransactionalOutbox", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Messaggio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tabella")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionalOutbox", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
