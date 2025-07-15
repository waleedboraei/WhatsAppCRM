using Microsoft.AspNetCore.Authorization;

namespace WhatsAppCRM.Presentation.Authorization.Policies
{
    public static class CustomAuthorizationPolicies
    {
        public static void AddCustomPolicies(this AuthorizationOptions options)
        {
            options.AddPolicy("CanManageTemplates", policy =>
                policy.RequireRole("Admin"));

            options.AddPolicy("CanSendMessages", policy =>
                policy.RequireRole("Admin", "Agent"));
        }
    }
}