using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using oai_poc_backend.Database;
using oai_poc_backend.Models;
using oai_poc_backend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Change to ApplicationUser
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.
//})
//Hämta connection string från appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

//Lägg till context i dependency injection container
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//Add cors
builder.Services.AddCors(options =>
{
    //Specifically allow localhost to access with credentials to enable signing in with cookies.
    options.AddPolicy("AllowLocalhost", options =>
    {
        options.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });

    options.AddPolicy("AllowAll", options =>
    {
        options.AllowAnyHeader();
        options.AllowAnyMethod();
        options.AllowAnyOrigin();
    });

});

//Allow cross-site requests. Default is SameSiteMode.Lax but then I could not include credentials from client side.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "oai-authentication-cookie";
    //options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.None;
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.Name = "oai-authentication-cookie";
    });

//Add user manager to enable quering against user tables.
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    // Lägger till signinmanager och usermanager
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddUserManager<UserManager<ApplicationUser>>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(GenericRepository<>));
builder.Services.AddScoped<ISettingCategoryRepository, SettingCategoryRepository>();
builder.Services.AddScoped<IOptionCategoryRepository, OptionCategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();

var app = builder.Build();

//Use cors
app.UseCors("AllowLocalhost");

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapIdentityApi<IdentityUser>();

app.MapControllers();

app.Run();
