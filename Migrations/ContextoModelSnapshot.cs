﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarea3_Registro_Estudiantes.DAL;

#nullable disable

namespace Tarea3_Registro_Estudiantes.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Tarea3_Registro_Estudiantes.Entidades.Carreras", b =>
                {
                    b.Property<int>("CarreraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("CarreraID");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("Tarea3_Registro_Estudiantes.Entidades.Estudiantes", b =>
                {
                    b.Property<int>("EstudiantesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarreraID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("EstudiantesID");

                    b.ToTable("Estudiantes");
                });
#pragma warning restore 612, 618
        }
    }
}
