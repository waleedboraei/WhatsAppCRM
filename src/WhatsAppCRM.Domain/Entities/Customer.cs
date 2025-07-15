namespace WhatsAppCRM.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
        public string Country { get; set; } = string.Empty;
        public DateTime LocalTime { get; set; }
        public bool IsOnline { get; set; }
        public bool HasUnreadMessages { get; set; }
    }
}