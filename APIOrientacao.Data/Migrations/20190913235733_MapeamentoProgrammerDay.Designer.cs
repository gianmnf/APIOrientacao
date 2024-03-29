﻿// <auto-generated />
using APIOrientacao.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIOrientacao.Data.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20190913235733_MapeamentoProgrammerDay")]
    partial class MapeamentoProgrammerDay
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIOrientacao.Data.Aluno", b =>
                {
                    b.Property<int>("IdPessoa")
                        .HasColumnName("IdPessoaAluno");

                    b.Property<int>("IdCurso")
                        .HasColumnName("IdCurso");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnName("Matricula")
                        .HasMaxLength(8);

                    b.Property<bool>("RegistroAtivo")
                        .HasColumnName("RegistroAtivo");

                    b.HasKey("IdPessoa")
                        .HasName("IdPessoa");

                    b.HasIndex("IdCurso");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("APIOrientacao.Data.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdCurso")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(150);

                    b.HasKey("IdCurso")
                        .HasName("IdCurso");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("APIOrientacao.Data.Pessoa", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdPessoa")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(300);

                    b.HasKey("IdPessoa")
                        .HasName("IdPessoa");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("APIOrientacao.Data.Aluno", b =>
                {
                    b.HasOne("APIOrientacao.Data.Curso", "Curso")
                        .WithMany("Alunos")
                        .HasForeignKey("IdCurso")
                        .HasConstraintName("FK_CursoAluno")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("APIOrientacao.Data.Pessoa", "Pessoa")
                        .WithOne("Aluno")
                        .HasForeignKey("APIOrientacao.Data.Aluno", "IdPessoa")
                        .HasConstraintName("PFK_PessoaAluno")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
