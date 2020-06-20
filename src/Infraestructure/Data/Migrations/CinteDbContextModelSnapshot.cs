﻿// <auto-generated />
using Cinte.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Data.Migrations
{
    [DbContext(typeof(CinteDbContext))]
    partial class CinteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("Cinte.Core.Entities.TipoDocumento", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("codigo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumentos");
                });
#pragma warning restore 612, 618
        }
    }
}
