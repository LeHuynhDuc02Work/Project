namespace Application.Dtos
{
    public class TagDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
    }

    public class TagViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
    }
}