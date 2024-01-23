using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Meta = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagsMaps",
                columns: table => new
                {
                    Post_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tag_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagsMaps", x => new { x.Post_id, x.Tag_id });
                    table.ForeignKey(
                        name: "FK_PostTagsMaps_Posts_Post_id",
                        column: x => x.Post_id,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagsMaps_Tags_Tag_id",
                        column: x => x.Tag_id,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("20d16cf9-2ce4-4209-b7e8-3ebb583701ed"), "This category is Travel", "Travel", "./././././" },
                    { new Guid("2a2f8dd1-56bd-4dc3-b5bc-2470d4b698e4"), "This category is Progaming", "Progaming", "./././././" },
                    { new Guid("7b8b916d-9a22-4749-bb1c-bdf58d724134"), "This category is Technology", "Technology", "./././././" },
                    { new Guid("a9e87acd-90c4-47ed-a333-eb19706664e9"), "This category is Technology", "Technology", "./././././" },
                    { new Guid("d4d0de55-252a-4567-86f7-d62178f5d80a"), "This category is Education", "Education", "./././././" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("26d2340c-f5ce-4a01-b7f5-0b9016f84fe8"), "Posts related to food recipes and culinary experiences.", "Food", "food" },
                    { new Guid("2d0f3c2b-d652-4cdf-9962-15c2222b92fe"), "Posts related to travel destinations and experiences.", "Travel", "travel" },
                    { new Guid("4ed1f39a-e8f7-4e03-bfa9-5fab8721fc4b"), "Posts related to scientific discoveries and research.", "Science", "science" },
                    { new Guid("75c448b1-c4a8-4cfb-8f38-ca42fa7368db"), "Posts related to technology and its advancements.", "Technology", "technology" },
                    { new Guid("7d053fc9-3b06-4317-a911-8b7bf06da98c"), "Posts related to programming languages and coding.", "Programming", "programming" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Description", "Meta", "Modified", "PostedOn", "Published", "ShortDescription", "Title", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("0ae7cf3e-6b8b-413e-a06d-34891cf11d00"), new Guid("a9e87acd-90c4-47ed-a333-eb19706664e9"), "This post highlights some of the top travel destinations around the world.", "travel, destinations", new DateTime(2024, 1, 9, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6445), new DateTime(2023, 12, 29, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6445), true, "Discover amazing places to visit", "Top Travel Destinations", "top-travel-destinations" },
                    { new Guid("5d5f8afc-77d7-44a4-a3e1-413ca0eeb4c4"), new Guid("20d16cf9-2ce4-4209-b7e8-3ebb583701ed"), "This post explores the scientific principles behind climate change and its effects.", "climate change, science", new DateTime(2023, 12, 30, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6450), new DateTime(2023, 12, 5, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6450), true, "Understanding climate change science", "The Science of Climate Change", "science-of-climate-change" },
                    { new Guid("7d9faf29-97ae-4d52-912f-67a88aa2632d"), new Guid("7b8b916d-9a22-4749-bb1c-bdf58d724134"), "In this post, we cover the basic concepts and technologies used in web development.", "web development, basics", new DateTime(2024, 1, 4, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6447), new DateTime(2023, 12, 20, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6447), true, "Learn the fundamentals of web development", "Web Development Basics", "web-development-basics" },
                    { new Guid("a8788c8b-f2fc-492b-8154-7676e7b1abad"), new Guid("d4d0de55-252a-4567-86f7-d62178f5d80a"), "This post provides an introduction to programming concepts and languages.", "programming, introduction", new DateTime(2024, 1, 16, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6437), new DateTime(2024, 1, 12, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6422), true, "Learn the basics of programming", "Introduction to Programming", "introduction-to-programming" },
                    { new Guid("cf7c56d8-686c-4f39-b084-e2139c4d8c89"), new Guid("2a2f8dd1-56bd-4dc3-b5bc-2470d4b698e4"), "In this post, we delve into the theory of relativity and its implications.", "relativity, physics", new DateTime(2024, 1, 13, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6443), new DateTime(2024, 1, 5, 11, 40, 47, 348, DateTimeKind.Local).AddTicks(6442), true, "Exploring Einstein's theory", "The Theory of Relativity", "theory-of-relativity" }
                });

            migrationBuilder.InsertData(
                table: "PostTagsMaps",
                columns: new[] { "Post_id", "Tag_id" },
                values: new object[,]
                {
                    { new Guid("0ae7cf3e-6b8b-413e-a06d-34891cf11d00"), new Guid("7d053fc9-3b06-4317-a911-8b7bf06da98c") },
                    { new Guid("5d5f8afc-77d7-44a4-a3e1-413ca0eeb4c4"), new Guid("26d2340c-f5ce-4a01-b7f5-0b9016f84fe8") },
                    { new Guid("7d9faf29-97ae-4d52-912f-67a88aa2632d"), new Guid("2d0f3c2b-d652-4cdf-9962-15c2222b92fe") },
                    { new Guid("a8788c8b-f2fc-492b-8154-7676e7b1abad"), new Guid("75c448b1-c4a8-4cfb-8f38-ca42fa7368db") },
                    { new Guid("cf7c56d8-686c-4f39-b084-e2139c4d8c89"), new Guid("4ed1f39a-e8f7-4e03-bfa9-5fab8721fc4b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagsMaps_Tag_id",
                table: "PostTagsMaps",
                column: "Tag_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PostTagsMaps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}