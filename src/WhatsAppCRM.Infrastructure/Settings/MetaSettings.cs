namespace WhatsAppCRM.Infrastructure.Settings
{
    public class MetaSettings
    {
        /// <summary>
        /// Access token for WhatsApp Business API
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// The phone number ID assigned by Meta for your WhatsApp Business account
        /// </summary>
        public string PhoneNumberId { get; set; } = string.Empty;

        /// <summary>
        /// The base URL for WhatsApp API (usually "https://graph.facebook.com")
        /// </summary>
        public string BaseUrl { get; set; } = "https://graph.facebook.com";

        /// <summary>
        /// API version to be used (e.g. "v18.0")
        /// </summary>
        public string ApiVersion { get; set; } = "v18.0";

        /// <summary>
        /// Webhook verify token
        /// </summary>
        public string VerifyToken { get; set; } = string.Empty;
    }
}