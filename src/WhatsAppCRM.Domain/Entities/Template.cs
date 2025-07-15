namespace WhatsAppCRM.Domain.Entities
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string? WhatsAppTemplateName { get; set; }
        public string? Language { get; set; }
    }
}