﻿// <auto-generated />

using System;
using API.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20190417221208_titleChallenge2")]
    partial class titleChallenge2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VcwBackend.Models.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("FileName");

                    b.Property<Guid?>("TableId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("VcwBackend.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VcwBackend.Models.Challenge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deadline");

                    b.Property<string>("Description");

                    b.Property<decimal?>("FirstBounce");

                    b.Property<decimal?>("SecondBounce");

                    b.Property<decimal?>("ThirdBounce");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("VcwBackend.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("TableId");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("VcwBackend.Models.ExamIdea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("FilterId");

                    b.Property<Guid?>("IdeaId");

                    b.Property<bool?>("IsPassed");

                    b.Property<int?>("Rank");

                    b.HasKey("Id");

                    b.HasIndex("FilterId");

                    b.HasIndex("IdeaId");

                    b.ToTable("ExamIdeas");
                });

            modelBuilder.Entity("VcwBackend.Models.Filter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("VcwBackend.Models.Idea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("InvitId");

                    b.HasKey("Id");

                    b.HasIndex("InvitId");

                    b.ToTable("Ideas");
                });

            modelBuilder.Entity("VcwBackend.Models.Invit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ChallengeId");

                    b.Property<bool?>("IsMaster");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("UserId");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("VcwBackend.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<byte[]>("Pic");

                    b.Property<string>("Title");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VcwBackend.Models.Attachment", b =>
                {
                    b.HasOne("VcwBackend.Models.Category", "Category")
                        .WithMany("Attachments")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("VcwBackend.Models.ExamIdea", b =>
                {
                    b.HasOne("VcwBackend.Models.Filter", "Filter")
                        .WithMany("ExamIdeas")
                        .HasForeignKey("FilterId");

                    b.HasOne("VcwBackend.Models.Idea", "Idea")
                        .WithMany("ExamIdeas")
                        .HasForeignKey("IdeaId");
                });

            modelBuilder.Entity("VcwBackend.Models.Idea", b =>
                {
                    b.HasOne("VcwBackend.Models.Invit", "Invite")
                        .WithMany("Ideas")
                        .HasForeignKey("InvitId");
                });

            modelBuilder.Entity("VcwBackend.Models.Invit", b =>
                {
                    b.HasOne("VcwBackend.Models.Challenge", "Challenge")
                        .WithMany("Invites")
                        .HasForeignKey("ChallengeId");

                    b.HasOne("VcwBackend.Models.User", "User")
                        .WithMany("Invites")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
