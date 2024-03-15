using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using HR_Project_Group3_Persistence.SeedData;
using HR_Project_Group3_Domain.Entities;
using HR_Project_Group3_Persistence.Context;
using AutoMapper;
using HR_Project_Group3_App.AutoMapper;
using WebApplication1.Models;
using HR_Project_Group3_App.IRepositories;
using HR_Project_Group3_Persistence.Repositories;
using HR_Project_Group3_App.Services;
using HR_Project_Group3_Persistence.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//MAPPER
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Berkay")));

builder.Services.AddIdentity<AppUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 8;
    opts.Password.RequireUppercase = true;
    opts.Password.RequireDigit = true;
    opts.Password.RequireLowercase = true;
    opts.Password.RequireNonAlphanumeric = true;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityValidator>();




var jwtSettings = builder.Configuration.GetSection("JwtSettings");

var secretKey = jwtSettings["secretKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{

    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

});

//REPOSÝTORÝES
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IJobRepository, JobRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();
builder.Services.AddTransient<ISiteManagerRepository, SiteManagerRepository>();


//MANAGERS
builder.Services.AddTransient<IJobService, JobManager>();
builder.Services.AddTransient<ICompanyService, CompanyManager>();
builder.Services.AddTransient<IAppUserService, AppUserManager>();
builder.Services.AddTransient<ISiteManagerService, SiteManagerManager>();



builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:5173") // Ýzin vermek istediðiniz kaynak
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


var app = builder.Build();

//SEEDDATA ADMÝN 
var serviceScope = app.Services.CreateScope();
AppDbContext _context = serviceScope.ServiceProvider.GetService<AppDbContext>()!;
UserManager<AppUser> userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>()!;
RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>()!;

AdminSeedData.Seed(userManager, roleManager, _context);


app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.MapFallbackToFile("/index.html");
app.Run();
