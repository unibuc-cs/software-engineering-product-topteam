using backend_MT.Data;
using backend_MT.Models;
using backend_MT.Repositories.AbonamentRepository;
using backend_MT.Repositories.CursRepository;
using backend_MT.Repositories.DisponibilitateRepository;
//using backend_MT.Repositories.ElevRepository;
using backend_MT.Repositories.FeedbackRepository;
using backend_MT.Repositories.GrupaRepository;
using backend_MT.Repositories.MaterialeRepository;
using backend_MT.Repositories.MesajRepository;
using backend_MT.Repositories.NotificareRepository;
using backend_MT.Repositories.ParticipareGrupaRepository;
using backend_MT.Repositories.PlataRepository;
using backend_MT.Repositories.PredareRepository;
using backend_MT.Repositories.PrezentaRepository;
using backend_MT.Repositories.RaspunsTemaRepository;
using backend_MT.Repositories.SedintaRepository;
using backend_MT.Repositories.SupportRepository;
using backend_MT.Repositories.TemaRepository;
using backend_MT.Service.AbonamentService;
using backend_MT.Service.CursService;
using backend_MT.Service.DisponibilitateService;
using backend_MT.Service.FeedbackService;
using backend_MT.Service.GrupaService;
using backend_MT.Service.MaterialeService;
using backend_MT.Service.MesajService;
using backend_MT.Service.NotificareService;
using backend_MT.Service.ParticipareGrupaService;
using backend_MT.Service.PlataService;
using backend_MT.Service.PredareService;
using backend_MT.Service.PrezentaService;
using backend_MT.Service.RaspunsTemaService;
using backend_MT.Service.SedintaService;
using backend_MT.Service.SupportService;
using backend_MT.Service.TemaService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Entity Framework Core with SQL Server
if (!builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<IAbonamentRepository, AbonamentRepository>();
builder.Services.AddScoped<ICursRepository, CursRepository>();
builder.Services.AddScoped<IDisponibilitateRepository, DisponibilitateRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IGrupaRepository, GrupaRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMesajRepository, MesajRepository>();
builder.Services.AddScoped<INotificareRepository, NotificareRepository>();
builder.Services.AddScoped<IPlataRepository, PlataRepository>();
builder.Services.AddScoped<IPredareRepository, PredareRepository>();
builder.Services.AddScoped<IPrezentaRepository, PrezentaRepository>();
builder.Services.AddScoped<IRaspunsTemaRepository, RaspunsTemaRepository>();
builder.Services.AddScoped<ISedintaRepository, SedintaRepository>();
builder.Services.AddScoped<ISupportRepository, SupportRepository>();
builder.Services.AddScoped<ITemaRepository, TemaRepository>();
builder.Services.AddScoped<IParticipareGrupaRepository, ParticipareGrupaRepository>();

// Services
builder.Services.AddScoped<IAbonamentService, AbonamentService>();
builder.Services.AddScoped<ICursService, CursService>();
builder.Services.AddScoped<IDisponibilitateService, DisponibilitateService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IGrupaService, GrupaService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IMesajService, MesajService>();
builder.Services.AddScoped<INotificareService, NotificareService>();
builder.Services.AddScoped<IPlataService, PlataService>();
builder.Services.AddScoped<IPredareService, PredareService>();
builder.Services.AddScoped<IPrezentaService, PrezentaService>();
builder.Services.AddScoped<IRaspunsTemaService, RaspunsTemaService>();
builder.Services.AddScoped<ISedintaService, SedintaService>();
builder.Services.AddScoped<ISupportService, SupportService>();
builder.Services.AddScoped<ITemaService, TemaService>();
builder.Services.AddScoped<IParticipareGrupaService, ParticipareGrupaService>();



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

app.Run();

public partial class Program { }
