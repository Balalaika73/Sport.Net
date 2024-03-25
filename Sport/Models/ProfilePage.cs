namespace Sport.Models
{
    public class ProfilePage
    {
        public User user { get; set; }
        public Role role { get; set; }
        public Trainer trainer { get; set; }
        public Abonement abonement { get; set; }
        public TypeAbonement typeAbonements { get; set; }
    }
}
