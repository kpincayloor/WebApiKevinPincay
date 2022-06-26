﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiKevinPincay.Data;

#nullable disable

namespace WebApiKevinPincay.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiKevinPincay.Entities.Cliente", b =>
                {
                    b.Property<int>("clienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("clienteId"), 1L, 1);

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("identificacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("clienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebApiKevinPincay.Entities.Cuenta", b =>
                {
                    b.Property<int>("cuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cuentaId"), 1L, 1);

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("numeroCuenta")
                        .HasColumnType("int");

                    b.Property<decimal>("saldoInicial")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("tipoCuentaId")
                        .HasColumnType("int");

                    b.HasKey("cuentaId");

                    b.HasIndex("clienteId");

                    b.HasIndex("tipoCuentaId");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("WebApiKevinPincay.Entities.Movimiento", b =>
                {
                    b.Property<int>("movimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("movimientoId"), 1L, 1);

                    b.Property<int>("clienteId")
                        .HasColumnType("int");

                    b.Property<int>("cuentaId")
                        .HasColumnType("int");

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("movimientoId");

                    b.HasIndex("clienteId");

                    b.HasIndex("cuentaId");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("WebApiKevinPincay.Entities.TipoCuenta", b =>
                {
                    b.Property<int>("tipoCuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tipoCuentaId"), 1L, 1);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("tipoCuentaId");

                    b.ToTable("TiposCuentas");

                    b.HasData(
                        new
                        {
                            tipoCuentaId = 1,
                            estado = true,
                            nombre = "Ahorro"
                        },
                        new
                        {
                            tipoCuentaId = 2,
                            estado = true,
                            nombre = "Corriente"
                        });
                });

            modelBuilder.Entity("WebApiKevinPincay.Entities.Cuenta", b =>
                {
                    b.HasOne("WebApiKevinPincay.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiKevinPincay.Entities.TipoCuenta", "TipoCuenta")
                        .WithMany()
                        .HasForeignKey("tipoCuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoCuenta");
                });

            modelBuilder.Entity("WebApiKevinPincay.Entities.Movimiento", b =>
                {
                    b.HasOne("WebApiKevinPincay.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiKevinPincay.Entities.Cuenta", "Cuenta")
                        .WithMany()
                        .HasForeignKey("cuentaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Cuenta");
                });
#pragma warning restore 612, 618
        }
    }
}
