﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Core.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HomeroomTeacher")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("50af162e-2f1b-4530-9c4b-41ffa63da5ba"),
                            FacultyId = new Guid("19e2369e-93ac-4b48-af36-a8f304a063ca"),
                            HomeroomTeacher = "Mr. Smith",
                            Name = "Mathematics"
                        },
                        new
                        {
                            Id = new Guid("815b5ef2-2c61-474d-8d1a-a83e1ed600ac"),
                            FacultyId = new Guid("6c0751ac-5c34-4c00-91f7-868e9bc1b5a4"),
                            HomeroomTeacher = "Ms. Johnson",
                            Name = "Science"
                        },
                        new
                        {
                            Id = new Guid("9f77ed66-aee1-499f-850b-eff51cd1d977"),
                            FacultyId = new Guid("ca12b74a-ce46-4a93-8da4-f738aab22590"),
                            HomeroomTeacher = "Mrs. Davis",
                            Name = "English"
                        },
                        new
                        {
                            Id = new Guid("6ffe5580-db44-400e-b03e-7662bb88ebaf"),
                            FacultyId = new Guid("ec0a691c-83c8-4635-a522-ae886862d05b"),
                            HomeroomTeacher = "Mr. Thompson",
                            Name = "History"
                        },
                        new
                        {
                            Id = new Guid("368751ec-5f80-42cc-b697-6574dee4ae3a"),
                            FacultyId = new Guid("5b8f3a90-2597-46ab-97bf-91ff547d70cd"),
                            HomeroomTeacher = "Mr. Wilson",
                            Name = "Computer Science"
                        });
                });

            modelBuilder.Entity("Core.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ca12b74a-ce46-4a93-8da4-f738aab22590"),
                            Name = "Faculty of Engineering"
                        },
                        new
                        {
                            Id = new Guid("6c0751ac-5c34-4c00-91f7-868e9bc1b5a4"),
                            Name = "Faculty of Science"
                        },
                        new
                        {
                            Id = new Guid("19e2369e-93ac-4b48-af36-a8f304a063ca"),
                            Name = "Faculty of Arts"
                        },
                        new
                        {
                            Id = new Guid("ec0a691c-83c8-4635-a522-ae886862d05b"),
                            Name = "Faculty of Business"
                        },
                        new
                        {
                            Id = new Guid("5b8f3a90-2597-46ab-97bf-91ff547d70cd"),
                            Name = "Faculty of Medicine"
                        });
                });

            modelBuilder.Entity("Core.Result", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Point")
                        .HasColumnType("float");

                    b.HasKey("StudentId", "ClassId", "SubjectId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Results");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("47900bea-7cb9-4379-a3f2-2b65f987e62f"),
                            ClassId = new Guid("50af162e-2f1b-4530-9c4b-41ffa63da5ba"),
                            SubjectId = new Guid("e30652d2-2386-41d6-bcd2-cf47c2a99d1a"),
                            Point = 85.0
                        },
                        new
                        {
                            StudentId = new Guid("dcf67f78-1eae-4616-b1f5-ae1a2b65c7ab"),
                            ClassId = new Guid("815b5ef2-2c61-474d-8d1a-a83e1ed600ac"),
                            SubjectId = new Guid("de9bdd8f-2bed-4470-8ed7-4d3467c5ce57"),
                            Point = 78.0
                        },
                        new
                        {
                            StudentId = new Guid("d75dca51-edc2-4475-9406-23b5e499f04b"),
                            ClassId = new Guid("9f77ed66-aee1-499f-850b-eff51cd1d977"),
                            SubjectId = new Guid("5f171354-fe12-4114-aa27-e5ef9be2c917"),
                            Point = 92.0
                        },
                        new
                        {
                            StudentId = new Guid("4361d2ac-247f-4bad-9b51-694e74c5094b"),
                            ClassId = new Guid("6ffe5580-db44-400e-b03e-7662bb88ebaf"),
                            SubjectId = new Guid("3db76a7b-6f01-4fc2-b703-12a05e8c83ac"),
                            Point = 80.0
                        },
                        new
                        {
                            StudentId = new Guid("20b8d57c-5163-4e42-9c88-efe17aa42e1e"),
                            ClassId = new Guid("368751ec-5f80-42cc-b697-6574dee4ae3a"),
                            SubjectId = new Guid("58750c14-582a-4196-93f8-b35713d370d7"),
                            Point = 88.0
                        });
                });

            modelBuilder.Entity("Core.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("20b8d57c-5163-4e42-9c88-efe17aa42e1e"),
                            Address = "123 Main St",
                            ClassId = new Guid("50af162e-2f1b-4530-9c4b-41ffa63da5ba"),
                            Email = "john@example.com",
                            FullName = "John Doe",
                            Gender = "Male"
                        },
                        new
                        {
                            Id = new Guid("4361d2ac-247f-4bad-9b51-694e74c5094b"),
                            Address = "456 Elm St",
                            ClassId = new Guid("815b5ef2-2c61-474d-8d1a-a83e1ed600ac"),
                            Email = "jane@example.com",
                            FullName = "Jane Smith",
                            Gender = "Female"
                        },
                        new
                        {
                            Id = new Guid("d75dca51-edc2-4475-9406-23b5e499f04b"),
                            Address = "789 Oak St",
                            ClassId = new Guid("368751ec-5f80-42cc-b697-6574dee4ae3a"),
                            Email = "mike@example.com",
                            FullName = "Mike Johnson",
                            Gender = "Male"
                        },
                        new
                        {
                            Id = new Guid("dcf67f78-1eae-4616-b1f5-ae1a2b65c7ab"),
                            Address = "321 Pine St",
                            ClassId = new Guid("6ffe5580-db44-400e-b03e-7662bb88ebaf"),
                            Email = "emily@example.com",
                            FullName = "Emily Williams",
                            Gender = "Female"
                        },
                        new
                        {
                            Id = new Guid("47900bea-7cb9-4379-a3f2-2b65f987e62f"),
                            Address = "654 Cedar St",
                            ClassId = new Guid("9f77ed66-aee1-499f-850b-eff51cd1d977"),
                            Email = "david@example.com",
                            FullName = "David Brown",
                            Gender = "Male"
                        });
                });

            modelBuilder.Entity("Core.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberOfCredits")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("58750c14-582a-4196-93f8-b35713d370d7"),
                            Name = "Mathematics",
                            NumberOfCredits = 4
                        },
                        new
                        {
                            Id = new Guid("3db76a7b-6f01-4fc2-b703-12a05e8c83ac"),
                            Name = "Science",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            Id = new Guid("e30652d2-2386-41d6-bcd2-cf47c2a99d1a"),
                            Name = "English",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            Id = new Guid("de9bdd8f-2bed-4470-8ed7-4d3467c5ce57"),
                            Name = "History",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            Id = new Guid("5f171354-fe12-4114-aa27-e5ef9be2c917"),
                            Name = "Computer Science",
                            NumberOfCredits = 4
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Core.Class", b =>
                {
                    b.HasOne("Core.Faculty", "Faculty")
                        .WithMany("Classes")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Core.Result", b =>
                {
                    b.HasOne("Core.Class", "Class")
                        .WithMany("Results")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Core.Student", "Student")
                        .WithMany("Results")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Core.Subject", "Subject")
                        .WithMany("Results")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Core.Student", b =>
                {
                    b.HasOne("Core.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Core.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Core.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Core.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Class", b =>
                {
                    b.Navigation("Results");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Core.Faculty", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("Core.Student", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("Core.Subject", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
