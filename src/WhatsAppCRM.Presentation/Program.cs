// File: src/WhatsAppCRM.Presentation/Program.cs
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Application.Mappings;
using WhatsAppCRM.Application.Services;
using WhatsAppCRM.Infrastructure.Data;
using WhatsAppCRM.Infrastructure.Repositories;
using WhatsAppCRM.Infrastructure.Services;
using WhatsAppCRM.Infrastructure.Settings;
using WhatsAppCRM.Presentation.Middleware;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<CrmDbContext>()
    .AddDefaultTokenProviders();

// Add Authorization policies
builder.Services.AddAuthorization(options =>
{
    WhatsAppCRM.Presentation.Authorization.Policies.CustomAuthorizationPolicies.AddCustomPolicies(options);
});
builder.Services.Configure<WhatsAppSettings>(builder.Configuration.GetSection("WhatsAppSettings"));
builder.Services.AddHttpClient<IWhatsAppMessageSender, WhatsAppMessageSender>();


// Application services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMessageService, WhatsAppMessagingService>();

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<ISettingRepository, SettingRepository>();

// Add HttpClient support
builder.Services.AddHttpClient();

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Apply migrations automatically at startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CrmDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseRequestLogging();

app.Run();
