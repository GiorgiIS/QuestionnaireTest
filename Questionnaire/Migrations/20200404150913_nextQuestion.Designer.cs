﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Questionnaire.Logic.Database;

namespace Questionnaire.Migrations
{
    [DbContext(typeof(QuestionnaireDbContext))]
    [Migration("20200404150913_nextQuestion")]
    partial class nextQuestion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Questionnaire.Logic.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Questionnaire.Logic.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("NextQuestionConditionId")
                        .HasColumnType("int");

                    b.Property<int?>("NextQuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NextQuestionConditionId");

                    b.HasIndex("NextQuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Questionnaire.Logic.Entities.QuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionnaireId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("QuestionAnswer");
                });

            modelBuilder.Entity("Questionnaire.Logic.Entities.Questionnaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Questionnaires");
                });

            modelBuilder.Entity("Questionnaire.Logic.Entities.Question", b =>
                {
                    b.HasOne("Questionnaire.Logic.Entities.Answer", "NextQuestionCondition")
                        .WithMany()
                        .HasForeignKey("NextQuestionConditionId");

                    b.HasOne("Questionnaire.Logic.Entities.Question", "NextQuestion")
                        .WithMany()
                        .HasForeignKey("NextQuestionId");
                });

            modelBuilder.Entity("Questionnaire.Logic.Entities.QuestionAnswer", b =>
                {
                    b.HasOne("Questionnaire.Logic.Entities.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId");

                    b.HasOne("Questionnaire.Logic.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.HasOne("Questionnaire.Logic.Entities.Questionnaire", null)
                        .WithMany("QuestionAnswers")
                        .HasForeignKey("QuestionnaireId");
                });
#pragma warning restore 612, 618
        }
    }
}
