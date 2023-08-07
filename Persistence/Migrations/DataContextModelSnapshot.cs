﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeOfEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfEvent")
                        .HasColumnType("int");

                    b.Property<Guid?>("ReaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VendorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("YearOfPublishing")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ReaderId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Domain.Reader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfChange")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeOfEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfEvent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("Domain.Book", b =>
                {
                    b.HasOne("Domain.Reader", "Reader")
                        .WithMany("Books")
                        .HasForeignKey("ReaderId");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Domain.Reader", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}