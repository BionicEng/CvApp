using CvApp.Business.Extensions;
using CvApp.Business.Middlewares;
using CvApp.Business.Services.Abstract;
using CvApp.Business.Services.Concrete;
using CvApp.Data.DbContexts;
using CvApp.Data.Entities;
using CvApp.Data.Services.Abstract;
using CvApp.Data.Services.Concrete;
using CvApp.Models.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Extension metot kullanarak db contexti eklendi.
builder.Services.AddMyDbContext(builder.Configuration);
//Loglama eklendi.
builder.Services.AddLogging(options => { options.AddConsole(); });

//Servisler eklendi.
builder.Services.AddScoped<IFileManager, FileService>();
builder.Services.AddScoped<IAuthManager, AuthService>();

//AutoMapper 
builder.Services.AddCustomAutoMapper();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],

        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],

        ValidateLifetime = true,
        LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = async context =>
        {
            var token = context.Request.Cookies["cv-app-token"];
            if (string.IsNullOrEmpty(token))
            {
                return;
            }
           // context.Token = token;
            // context.Request.Headers["Authorization"] = "Bearer " + token;
        }
    };
});

//IRepositoryManager eklendi.
builder.Services.AddScoped<IRepositoryManager<CertificateEntity>, Repository<CertificateEntity>>();
builder.Services.AddScoped<IRepositoryManager<EducationEntity>, Repository<EducationEntity>>();
builder.Services.AddScoped<IRepositoryManager<JobInformationEntity>, Repository<JobInformationEntity>>();
builder.Services.AddScoped<IRepositoryManager<KnownProgramEntity>, Repository<KnownProgramEntity>>();
builder.Services.AddScoped<IRepositoryManager<LanguageEntity>, Repository<LanguageEntity>>();
builder.Services.AddScoped<IRepositoryManager<PersonEntity>, Repository<PersonEntity>>();
builder.Services.AddScoped<IRepositoryManager<UserEntity>, Repository<UserEntity>>();
builder.Services.AddScoped<IRepositoryManager<ServiceEntity>, Repository<ServiceEntity>>();
builder.Services.AddScoped<IRepositoryManager<MessageEntity>, Repository<MessageEntity>>();
builder.Services.AddScoped<IRepositoryManager<ReferanceEntity>, Repository<ReferanceEntity>>();
builder.Services.AddScoped<IRepositoryManager<FactEntity>, Repository<FactEntity>>();

var app = builder.Build();

//Extension ile eklendi.
//app.UseRequestLogging();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseJWTDirectToLogin();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCustomAuthorization();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
