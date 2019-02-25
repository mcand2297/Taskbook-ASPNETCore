﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taskbook_ASPNETCore.Models;

namespace Taskbook_ASPNETCore.Migrations
{
    [DbContext(typeof(TaskbookDBContext))]
    partial class TaskbookDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.Activity", b =>
                {
                    b.Property<int>("activityId");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<int>("teamId");

                    b.Property<string>("title")
                        .IsRequired();

                    b.HasKey("activityId");

                    b.ToTable("activities");
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.Response", b =>
                {
                    b.Property<int>("responseId");

                    b.Property<int>("activityId");

                    b.Property<string>("content")
                        .IsRequired();

                    b.HasKey("responseId");

                    b.ToTable("responses");
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.Task", b =>
                {
                    b.Property<int>("taskId");

                    b.Property<int>("activityId");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<bool>("isCompleted");

                    b.HasKey("taskId");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.TaskUser", b =>
                {
                    b.Property<int>("taskId");

                    b.Property<int>("userId");

                    b.HasKey("taskId", "userId");

                    b.HasIndex("userId");

                    b.ToTable("taskUsers");
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.Team", b =>
                {
                    b.Property<int>("teamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("teamId");

                    b.ToTable("teams");
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.TeamUser", b =>
                {
                    b.Property<int>("teamId");

                    b.Property<int>("userId");

                    b.Property<bool>("isCreator");

                    b.HasKey("teamId", "userId");

                    b.HasIndex("userId");

                    b.ToTable("teamUsers");
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.User", b =>
                {
                    b.Property<int>("userId");

                    b.Property<string>("displayName")
                        .IsRequired();

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<DateTime>("lastLogin");

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<int>("responseId");

                    b.HasKey("userId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.Activity", b =>
                {
                    b.HasOne("Taskbook_ASPNETCore.Models.Team", "team")
                        .WithMany("activities")
                        .HasForeignKey("activityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.Response", b =>
                {
                    b.HasOne("Taskbook_ASPNETCore.Models.Activity", "activity")
                        .WithMany("responses")
                        .HasForeignKey("responseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.Task", b =>
                {
                    b.HasOne("Taskbook_ASPNETCore.Models.Activity", "activity")
                        .WithMany("tasks")
                        .HasForeignKey("taskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.TaskUser", b =>
                {
                    b.HasOne("Taskbook_ASPNETCore.Models.Task", "task")
                        .WithMany("taskUsers")
                        .HasForeignKey("taskId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Taskbook_ASPNETCore.Models.User", "user")
                        .WithMany("taskUsers")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.TeamUser", b =>
                {
                    b.HasOne("Taskbook_ASPNETCore.Models.Team", "team")
                        .WithMany("teamUsers")
                        .HasForeignKey("teamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Taskbook_ASPNETCore.Models.User", "user")
                        .WithMany("teamUsers")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Taskbook_ASPNETCore.Models.User", b =>
                {
                    b.HasOne("Taskbook_ASPNETCore.Models.Response", "response")
                        .WithOne("user")
                        .HasForeignKey("Taskbook_ASPNETCore.Models.User", "userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
