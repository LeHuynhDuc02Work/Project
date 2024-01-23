namespace Core
{
    public class PostTagMap
    {
        public Guid Post_id { get; set; }
        public Guid Tag_id { get; set; }

        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}