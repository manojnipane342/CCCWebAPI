using AutoMapper;
using CCCWebAPI.Helpers;
using CCCWebAPI.Models.EF_Models;
using CCCWebAPI.Repository.Abstract;
using CCCWebAPI.Repository.Repository;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddScoped<CCCWebAPIEntities>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IIndividualInfoRepository, IndividualInfoRepository>();
builder.Services.AddScoped<IPlumberInformationRepository, PlumberInformationRepository>();
builder.Services.AddScoped<IlocalInfoRepository, localInfoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.SaveToken = true;
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     // установка ключа безопасности
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Secret").Value)),
                     // валидация ключа безопасности
                     ValidateIssuerSigningKey = true,
                 };
             });


//builder.Services.AddDbContext<CCCDBContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

//});

var mapping = new MapperConfiguration(conf =>
{
    conf.AddProfile(new AutoMapperProfile());
});
IMapper map = mapping.CreateMapper();
builder.Services.AddSingleton(map);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
