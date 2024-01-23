﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240119044047_InitialDbContext")]
    partial class InitialDbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Core.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4d0de55-252a-4567-86f7-d62178f5d80a"),
                            Description = "This category is Education",
                            Name = "Education",
                            UrlSlug = "./././././"
                        },
                        new
                        {
                            Id = new Guid("2a2f8dd1-56bd-4dc3-b5bc-2470d4b698e4"),
                            Description = "This category is Progaming",
                            Name = "Progaming",
                            UrlSlug = "./././././"
                        },
                        new
                        {
                            Id = new Guid("a9e87acd-90c4-47ed-a333-eb19706664e9"),
                            Description = "This category is Technology",
                            Name = "Technology",
                            UrlSlug = "./././././"
                        },
                        new
                        {
                            Id = new Guid("7b8b916d-9a22-4749-bb1c-bdf58d724134"),
                            Description = "This category is Technology",
                            Name = "Technology",
                            UrlSlug = "./././././"
                        },
                        new
                        {
                            Id = new Guid("20d16cf9-2ce4-4209-b7e8-3ebb583701ed"),
                            Description = "This category is Travel",
                            Name = "Travel",
                            UrlSlug = "./././././"
                        });
                });

            modelBuilder.Entity("Core.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Meta")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a8788c8b-f2fc-492b-8154-7676e7b1abad"),
                            CategoryId = new Guid("d4d0de55-252a-4567-86f7-d62178f5d80a"),
                            Description = "This post provides an introduction to programming concepts and languages.",
                            Meta = "programming, introduction",
                            Modified = new DateTime(2024, 1, 16, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6437),
                            PostedOn = new DateTime(2024, 1, 12, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6422),
                            Published = true,
                            ShortDescription = "Learn the basics of programming",
                            Title = "Introduction to Programming",
                            UrlSlug = "introduction-to-programming"
                        },
                        new
                        {
                            Id = new Guid("cf7c56d8-686c-4f39-b084-e2139c4d8c89"),
                            CategoryId = new Guid("2a2f8dd1-56bd-4dc3-b5bc-2470d4b698e4"),
                            Description = "In this post, we delve into the theory of relativity and its implications.",
                            Meta = "relativity, physics",
                            Modified = new DateTime(2024, 1, 13, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6443),
                            PostedOn = new DateTime(2024, 1, 5, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6442),
                            Published = true,
                            ShortDescription = "Exploring Einstein's theory",
                            Title = "The Theory of Relativity",
                            UrlSlug = "theory-of-relativity"
                        },
                        new
                        {
                            Id = new Guid("0ae7cf3e-6b8b-413e-a06d-34891cf11d00"),
                            CategoryId = new Guid("a9e87acd-90c4-47ed-a333-eb19706664e9"),
                            Description = "This post highlights some of the top travel destinations around the world.",
                            Meta = "travel, destinations",
                            Modified = new DateTime(2024, 1, 9, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6445),
                            PostedOn = new DateTime(2023, 12, 29, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6445),
                            Published = true,
                            ShortDescription = "Discover amazing places to visit",
                            Title = "Top Travel Destinations",
                            UrlSlug = "top-travel-destinations"
                        },
                        new
                        {
                            Id = new Guid("7d9faf29-97ae-4d52-912f-67a88aa2632d"),
                            CategoryId = new Guid("7b8b916d-9a22-4749-bb1c-bdf58d724134"),
                            Description = "In this post, we cover the basic concepts and technologies used in web development.",
                            Meta = "web development, basics",
                            Modified = new DateTime(2024, 1, 4, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6447),
                            PostedOn = new DateTime(2023, 12, 20, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6447),
                            Published = true,
                            ShortDescription = "Learn the fundamentals of web development",
                            Title = "Web Development Basics",
                            UrlSlug = "web-development-basics"
                        },
                        new
                        {
                            Id = new Guid("5d5f8afc-77d7-44a4-a3e1-413ca0eeb4c4"),
                            CategoryId = new Guid("20d16cf9-2ce4-4209-b7e8-3ebb583701ed"),
                            Description = "This post explores the scientific principles behind climate change and its effects.",
                            Meta = "climate change, science",
                            Modified = new DateTime(2023, 12, 30, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6450),
                            PostedOn = new DateTime(2023, 12, 5, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6450),
                            Published = true,
                            ShortDescription = "Understanding climate change science",
                            Title = "The Science of Climate Change",
                            UrlSlug = "science-of-climate-change"
                        });
                });

            modelBuilder.Entity("Core.PostTagMap", b =>
                {
                    b.Property<Guid>("Post_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Tag_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Post_id", "Tag_id");

                    b.HasIndex("Tag_id");

                    b.ToTable("PostTagsMaps");

                    b.HasData(
                        new
                        {
                            Post_id = new Guid("a8788c8b-f2fc-492b-8154-7676e7b1abad"),
                            Tag_id = new Guid("75c448b1-c4a8-4cfb-8f38-ca42fa7368db")
                        },
                        new
                        {
                            Post_id = new Guid("cf7c56d8-686c-4f39-b084-e2139c4d8c89"),
                            Tag_id = new Guid("4ed1f39a-e8f7-4e03-bfa9-5fab8721fc4b")
                        },
                        new
                        {
                            Post_id = new Guid("0ae7cf3e-6b8b-413e-a06d-34891cf11d00"),
                            Tag_id = new Guid("7d053fc9-3b06-4317-a911-8b7bf06da98c")
                        },
                        new
                        {
                            Post_id = new Guid("7d9faf29-97ae-4d52-912f-67a88aa2632d"),
                            Tag_id = new Guid("2d0f3c2b-d652-4cdf-9962-15c2222b92fe")
                        },
                        new
                        {
                            Post_id = new Guid("5d5f8afc-77d7-44a4-a3e1-413ca0eeb4c4"),
                            Tag_id = new Guid("26d2340c-f5ce-4a01-b7f5-0b9016f84fe8")
                        });
                });

            modelBuilder.Entity("Core.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75c448b1-c4a8-4cfb-8f38-ca42fa7368db"),
                            Description = "Posts related to technology and its advancements.",
                            Name = "Technology",
                            UrlSlug = "technology"
                        },
                        new
                        {
                            Id = new Guid("4ed1f39a-e8f7-4e03-bfa9-5fab8721fc4b"),
                            Description = "Posts related to scientific discoveries and research.",
                            Name = "Science",
                            UrlSlug = "science"
                        },
                        new
                        {
                            Id = new Guid("7d053fc9-3b06-4317-a911-8b7bf06da98c"),
                            Description = "Posts related to programming languages and coding.",
                            Name = "Programming",
                            UrlSlug = "programming"
                        },
                        new
                        {
                            Id = new Guid("2d0f3c2b-d652-4cdf-9962-15c2222b92fe"),
                            Description = "Posts related to travel destinations and experiences.",
                            Name = "Travel",
                            UrlSlug = "travel"
                        },
                        new
                        {
                            Id = new Guid("26d2340c-f5ce-4a01-b7f5-0b9016f84fe8"),
                            Description = "Posts related to food recipes and culinary experiences.",
                            Name = "Food",
                            UrlSlug = "food"
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

            modelBuilder.Entity("Core.Post", b =>
                {
                    b.HasOne("Core.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.PostTagMap", b =>
                {
                    b.HasOne("Core.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("Post_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("Tag_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
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

            modelBuilder.Entity("Core.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Core.Post", b =>
                {
                    b.Navigation("PostTags");
                });

            modelBuilder.Entity("Core.Tag", b =>
                {
                    b.Navigation("PostTags");
                });
#pragma warning restore 612, 618
        }
    }
}