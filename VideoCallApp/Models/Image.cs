namespace VideoCallApp.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
