using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using signup_login.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//to connect application to database
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("ConnectionString")!;
    options.UseSqlServer(connectionString);
});

//Incorporate Identity into Database
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();

//Change the default path to Login when user fails login attempt
builder.Services.ConfigureApplicationCookie(configure =>
{
    configure.LoginPath = "/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();