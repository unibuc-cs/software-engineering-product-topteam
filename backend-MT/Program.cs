using backend_MT.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using backend_MT.Models;
using backend_MT.Repositories.CursRepository;
using backend_MT.Repositories.DisponibilitateRepository;
//using backend_MT.Repositories.ElevRepository;
using backend_MT.Repositories.FeedbackRepository;
using backend_MT.Repositories.GrupaRepository;
using backend_MT.Repositories.MaterialeRepository;
using backend_MT.Repositories.MesajRepository;
using backend_MT.Repositories.NotificareRepository;
using backend_MT.Repositories.PlataRepository;
using backend_MT.Repositories.RaspunsTemaRepository;
using backend_MT.Repositories.SedintaRepository;
using backend_MT.Repositories.SupportRepository;
using backend_MT.Repositories.TemaRepository;
using backend_MT.Service.CursService;
using backend_MT.Service.DisponibilitateService;
using backend_MT.Service.FeedbackService;
using backend_MT.Service.GrupaService;
using backend_MT.Service.MaterialeService;
using backend_MT.Service.MesajService;
using backend_MT.Service.NotificareService;
using backend_MT.Service.PlataService;
using backend_MT.Service.RaspunsTemaService;
using backend_MT.Service.SedintaService;
using backend_MT.Service.SupportService;
using backend_MT.Service.TemaService;
using backend_MT.Service.UserService;
using backend_MT.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using backend_MT.Helpers;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure Entity Framework Core with SQL Server
if (!builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        RoleClaimType = ClaimTypes.Role
    };
});

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendApp", policy =>
    {
        policy.SetIsOriginAllowed(origin =>
            new Uri(origin).Host == "localhost") // Allow all localhost origins
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});



// Repositories
builder.Services.AddScoped<ICursRepository, CursRepository>();
builder.Services.AddScoped<IDisponibilitateRepository, DisponibilitateRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IGrupaRepository, GrupaRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMesajRepository, MesajRepository>();
builder.Services.AddScoped<INotificareRepository, NotificareRepository>();
builder.Services.AddScoped<IPlataRepository, PlataRepository>();
builder.Services.AddScoped<IRaspunsTemaRepository, RaspunsTemaRepository>();
builder.Services.AddScoped<ISedintaRepository, SedintaRepository>();
builder.Services.AddScoped<ISupportRepository, SupportRepository>();
builder.Services.AddScoped<ITemaRepository, TemaRepository>();

var mapperConfig = new MapperConfiguration(mc =>
{
	// Resolve DbContext from the service provider
	var serviceProvider = builder.Services.BuildServiceProvider();
	var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
	mc.AddProfile(new MapperProfile(dbContext)); // Create and add your profile manually
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Services
builder.Services.AddScoped<ICursService, CursService>();
builder.Services.AddScoped<IDisponibilitateService, DisponibilitateService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IGrupaService, GrupaService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IMesajService, MesajService>();
builder.Services.AddScoped<INotificareService, NotificareService>();
builder.Services.AddScoped<IPlataService, PlataService>();
builder.Services.AddScoped<IRaspunsTemaService, RaspunsTemaService>();
builder.Services.AddScoped<ISedintaService, SedintaService>();
builder.Services.AddScoped<ISupportService, SupportService>();
builder.Services.AddScoped<ITemaService, TemaService>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();

app.UseCors("AllowFrontendApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await Seed.InitializeRoles(app);

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseAuthentication();

app.Run();
