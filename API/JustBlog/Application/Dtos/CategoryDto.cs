namespace Application.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
    }

    public class CategoryViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
    }
}