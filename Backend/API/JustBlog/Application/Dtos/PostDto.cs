namespace Application.Dtos
{
    public class PostDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
        public string Meta { get; set; }
        public bool Published { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class PostViewDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
        public string Meta { get; set; }
        public bool Published { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime Modified { get; set; }
    }
}