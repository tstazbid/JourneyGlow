namespace JourneyGlow.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        // There can multiple blogs under one tag
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
