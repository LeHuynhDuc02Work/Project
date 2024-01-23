using Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTagMap> PostTagsMaps { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTagMap>()
                    .HasKey(pc => new { pc.Post_id, pc.Tag_id });
            modelBuilder.Entity<PostTagMap>()
                    .HasOne(p => p.Post)
                    .WithMany(pc => pc.PostTags)
                    .HasForeignKey(c => c.Post_id);
            modelBuilder.Entity<PostTagMap>()
                    .HasOne(p => p.Tag)
                    .WithMany(pc => pc.PostTags)
                    .HasForeignKey(c => c.Tag_id);
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }

    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = Guid.Parse("d4d0de55-252a-4567-86f7-d62178f5d80a"), Name = "Education", Description = "This category is Education", UrlSlug = "./././././" },
                new Category { Id = Guid.Parse("2a2f8dd1-56bd-4dc3-b5bc-2470d4b698e4"), Name = "Progaming", Description = "This category is Progaming", UrlSlug = "./././././" },
                new Category { Id = Guid.Parse("a9e87acd-90c4-47ed-a333-eb19706664e9"), Name = "Technology", Description = "This category is Technology", UrlSlug = "./././././" },
                new Category { Id = Guid.Parse("7b8b916d-9a22-4749-bb1c-bdf58d724134"), Name = "Technology", Description = "This category is Technology", UrlSlug = "./././././" },
                new Category { Id = Guid.Parse("20d16cf9-2ce4-4209-b7e8-3ebb583701ed"), Name = "Travel", Description = "This category is Travel", UrlSlug = "./././././" }
                );
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = Guid.Parse("A8788C8B-F2FC-492B-8154-7676E7B1ABAD"),
                    Title = "Introduction to Programming",
                    ShortDescription = "Learn the basics of programming",
                    Description = "This post provides an introduction to programming concepts and languages.",
                    Meta = "programming, introduction",
                    UrlSlug = "introduction-to-programming",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-7),
                    Modified = DateTime.Now.AddDays(-3),
                    CategoryId = Guid.Parse("d4d0de55-252a-4567-86f7-d62178f5d80a")
                },
                new Post
                {
                    Id = Guid.Parse("CF7C56D8-686C-4F39-B084-E2139C4D8C89"),
                    Title = "The Theory of Relativity",
                    ShortDescription = "Exploring Einstein's theory",
                    Description = "In this post, we delve into the theory of relativity and its implications.",
                    Meta = "relativity, physics",
                    UrlSlug = "theory-of-relativity",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-14),
                    Modified = DateTime.Now.AddDays(-6),
                    CategoryId = Guid.Parse("2a2f8dd1-56bd-4dc3-b5bc-2470d4b698e4")
                },
                new Post
                {
                    Id = Guid.Parse("0AE7CF3E-6B8B-413E-A06D-34891CF11D00"),
                    Title = "Top Travel Destinations",
                    ShortDescription = "Discover amazing places to visit",
                    Description = "This post highlights some of the top travel destinations around the world.",
                    Meta = "travel, destinations",
                    UrlSlug = "top-travel-destinations",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-21),
                    Modified = DateTime.Now.AddDays(-10),
                    CategoryId = Guid.Parse("a9e87acd-90c4-47ed-a333-eb19706664e9")
                },
                new Post
                {
                    Id = Guid.Parse("7D9FAF29-97AE-4D52-912F-67A88AA2632D"),
                    Title = "Web Development Basics",
                    ShortDescription = "Learn the fundamentals of web development",
                    Description = "In this post, we cover the basic concepts and technologies used in web development.",
                    Meta = "web development, basics",
                    UrlSlug = "web-development-basics",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-30),
                    Modified = DateTime.Now.AddDays(-15),
                    CategoryId = Guid.Parse("7b8b916d-9a22-4749-bb1c-bdf58d724134")
                },
                new Post
                {
                    Id = Guid.Parse("5D5F8AFC-77D7-44A4-A3E1-413CA0EEB4C4"),
                    Title = "The Science of Climate Change",
                    ShortDescription = "Understanding climate change science",
                    Description = "This post explores the scientific principles behind climate change and its effects.",
                    Meta = "climate change, science",
                    UrlSlug = "science-of-climate-change",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-45),
                    Modified = DateTime.Now.AddDays(-20),
                    CategoryId = Guid.Parse("20d16cf9-2ce4-4209-b7e8-3ebb583701ed")
                }
                );
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = Guid.Parse("75C448B1-C4A8-4CFB-8F38-CA42FA7368DB"),
                    Name = "Technology",
                    UrlSlug = "technology",
                    Description = "Posts related to technology and its advancements."
                },
                new Tag
                {
                    Id = Guid.Parse("4ED1F39A-E8F7-4E03-BFA9-5FAB8721FC4B"),
                    Name = "Science",
                    UrlSlug = "science",
                    Description = "Posts related to scientific discoveries and research."
                },
                new Tag
                {
                    Id = Guid.Parse("7D053FC9-3B06-4317-A911-8B7BF06DA98C"),
                    Name = "Programming",
                    UrlSlug = "programming",
                    Description = "Posts related to programming languages and coding."
                },
                new Tag
                {
                    Id = Guid.Parse("2D0F3C2B-D652-4CDF-9962-15C2222B92FE"),
                    Name = "Travel",
                    UrlSlug = "travel",
                    Description = "Posts related to travel destinations and experiences."
                },
                new Tag
                {
                    Id = Guid.Parse("26D2340C-F5CE-4A01-B7F5-0B9016F84FE8"),
                    Name = "Food",
                    UrlSlug = "food",
                    Description = "Posts related to food recipes and culinary experiences."
                }
                );
            modelBuilder.Entity<PostTagMap>().HasData(
                new PostTagMap { Post_id = Guid.Parse("A8788C8B-F2FC-492B-8154-7676E7B1ABAD"), Tag_id = Guid.Parse("75C448B1-C4A8-4CFB-8F38-CA42FA7368DB") },
                new PostTagMap { Post_id = Guid.Parse("CF7C56D8-686C-4F39-B084-E2139C4D8C89"), Tag_id = Guid.Parse("4ED1F39A-E8F7-4E03-BFA9-5FAB8721FC4B") },
                new PostTagMap { Post_id = Guid.Parse("0AE7CF3E-6B8B-413E-A06D-34891CF11D00"), Tag_id = Guid.Parse("7D053FC9-3B06-4317-A911-8B7BF06DA98C") },
                new PostTagMap { Post_id = Guid.Parse("7D9FAF29-97AE-4D52-912F-67A88AA2632D"), Tag_id = Guid.Parse("2D0F3C2B-D652-4CDF-9962-15C2222B92FE") },
                new PostTagMap { Post_id = Guid.Parse("5D5F8AFC-77D7-44A4-A3E1-413CA0EEB4C4"), Tag_id = Guid.Parse("26D2340C-F5CE-4A01-B7F5-0B9016F84FE8") }
                );
        }
    }
}