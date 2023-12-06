﻿// <auto-generated />
using CRUD.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUD.Migrations
{
    [DbContext(typeof(DbCrudContext))]
    [Migration("20231206034242_InitialMigration2")]
    partial class InitialMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CRUD.Models.Data.Departamento", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamento"), 1L, 1);

                    b.Property<string>("NombreDepartamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDepartamento");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdDepartamento"));

                    b.ToTable("Departamento", (string)null);
                });

            modelBuilder.Entity("CRUD.Models.Data.Distrito", b =>
                {
                    b.Property<int>("IdProvincia")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("IdDistrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDistrito"), 1L, 1);

                    b.Property<string>("NombreProvincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProvincia", "IdDistrito");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdProvincia", "IdDistrito"));

                    b.ToTable("Distrito", (string)null);
                });

            modelBuilder.Entity("CRUD.Models.Data.Provincia", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("IdProvincia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProvincia"), 1L, 1);

                    b.Property<string>("NombreDepartamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDepartamento", "IdProvincia");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdDepartamento", "IdProvincia"));

                    b.ToTable("Provincia", (string)null);
                });

            modelBuilder.Entity("CRUD.Models.Data.Trabajador", b =>
                {
                    b.Property<int>("IdTrabajador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTrabajador"), 1L, 1);

                    b.Property<int>("IdDistrito")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTrabajador");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdTrabajador"));

                    b.ToTable("Trabajador", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
