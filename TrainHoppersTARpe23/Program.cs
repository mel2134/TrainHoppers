using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainHoppers.ApplicationServices.Services;
using TrainHoppers.Core.Domain;
using TrainHoppers.Core.ServiceInterface;
using TrainHoppers.Data;
using TrainHoppersTARpe23.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAbilitiesServices, AbilitiesServices> ();
builder.Services.AddScoped<IFileServices, FileServices>();
builder.Services.AddScoped<IAccountsServices, AccountsServices> ();
builder.Services.AddScoped<IEmailsServices, EmailsServices>();
builder.Services.AddDbContext<TrainHoppersContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options=>
   { 
       options.SignIn.RequireConfirmedAccount = true;
       options.Password.RequiredLength = 3;
       options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
       options.Lockout.MaxFailedAccessAttempts = 3;
       options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
   })
    .AddEntityFrameworkStores<TrainHoppersContext>()
    .AddDefaultTokenProviders()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
    .AddDefaultUI();


builder.Services.Configure<DataProtectionTokenProviderOptions>(
    options => options.TokenLifespan = TimeSpan.FromHours(5)
    );

builder.Services.Configure<CustomEmailConfirmationTokenProviderOptions>(
    options => options.TokenLifespan = TimeSpan.FromDays(3)
    );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
