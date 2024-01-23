using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTagMap> PostTagsMaps { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
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
                new Category { Name = "Education", Description = "This category is Education", UrlSlug = "./././././"  },
                new Category { Name = "Progaming", Description = "This category is Progaming", UrlSlug = "./././././"  },
                new Category { Name = "Technology", Description = "This category is Technology", UrlSlug = "./././././"  },
                new Category { Name = "Technology", Description = "This category is Technology", UrlSlug = "./././././"  },
                new Category { Name = "Travel", Description = "This category is Travel", UrlSlug = "./././././"  }
                );
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Introduction to Programming",
                    ShortDescription = "Learn the basics of programming",
                    Description = "This post provides an introduction to programming concepts and languages.",
                    Meta = "programming, introduction",
                    UrlSlug = "introduction-to-programming",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-7),
                    Modified = DateTime.Now.AddDays(-3)
                },
                new Post
                {
                    Id = 2,
                    Title = "The Theory of Relativity",
                    ShortDescription = "Exploring Einstein's theory",
                    Description = "In this post, we delve into the theory of relativity and its implications.",
                    Meta = "relativity, physics",
                    UrlSlug = "theory-of-relativity",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-14),
                    Modified = DateTime.Now.AddDays(-6)
                },
                new Post
                {
                    Id = 3,
                    Title = "Top Travel Destinations",
                    ShortDescription = "Discover amazing places to visit",
                    Description = "This post highlights some of the top travel destinations around the world.",
                    Meta = "travel, destinations",
                    UrlSlug = "top-travel-destinations",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-21),
                    Modified = DateTime.Now.AddDays(-10)
                },
                new Post
                {
                    Id = 4,
                    Title = "Web Development Basics",
                    ShortDescription = "Learn the fundamentals of web development",
                    Description = "In this post, we cover the basic concepts and technologies used in web development.",
                    Meta = "web development, basics",
                    UrlSlug = "web-development-basics",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-30),
                    Modified = DateTime.Now.AddDays(-15)
                },
                new Post
                {
                    Id = 5,
                    Title = "The Science of Climate Change",
                    ShortDescription = "Understanding climate change science",
                    Description = "This post explores the scientific principles behind climate change and its effects.",
                    Meta = "climate change, science",
                    UrlSlug = "science-of-climate-change",
                    Published = true,
                    PostedOn = DateTime.Now.AddDays(-45),
                    Modified = DateTime.Now.AddDays(-20)
                }
                );
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Name = "Technology",
                    UrlSlug = "technology",
                    Description = "Posts related to technology and its advancements."
                },
                new Tag
                {
                    Id = 2,
                    Name = "Science",
                    UrlSlug = "science",
                    Description = "Posts related to scientific discoveries and research."
                },
                new Tag
                {
                    Id = 3,
                    Name = "Programming",
                    UrlSlug = "programming",
                    Description = "Posts related to programming languages and coding."
                },
                new Tag
                {
                    Id = 4,
                    Name = "Travel",
                    UrlSlug = "travel",
                    Description = "Posts related to travel destinations and experiences."
                },
                new Tag
                {
                    Id = 5,
                    Name = "Food",
                    UrlSlug = "food",
                    Description = "Posts related to food recipes and culinary experiences."
                }
                );
            modelBuilder.Entity<PostTagMap>().HasData(
                new PostTagMap { Post_id = 1, Tag_id = 2},
                new PostTagMap { Post_id = 2, Tag_id = 3},
                new PostTagMap { Post_id = 3, Tag_id = 1},
                new PostTagMap { Post_id = 4, Tag_id = 5},
                new PostTagMap { Post_id = 5, Tag_id = 4}
                );
        }
    }
}
