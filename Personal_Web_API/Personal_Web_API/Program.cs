using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Personal_Web_API.Models;
using Personal_Web_API.Services.Implementations;
using Personal_Web_API.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonalWebDbContext>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAboutMeService, AboutMeService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IFutureProjectService, FutureProjectService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();

builder.Services.AddCors(options => options.AddPolicy(name: "PersonalWebOrigin",
	policy =>
	{
		policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
	}));

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		ValidateAudience = false,
		ValidateIssuer = false,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
				builder.Configuration.GetSection("Authentication:Schemes:Bearer:SigningKeys:0:Value").Value!))
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/* if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
} */

app.UseCors("PersonalWebOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
