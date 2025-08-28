using System.Reflection;
using Microsoft.OpenApi.Models;
using RecipeApi.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RecipeApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(opt =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Recipe API Documentation", Version = "v1.0" });

    opt.IncludeXmlComments(xmlPath);
    opt.EnableAnnotations();

    //Can add security here at a later date with opt.AddSecurityDefinition(...) and opt.AddSecurityRequirement

    //Can add filters here with opt.OperationFilter<FILTERCLASSHERE>();
});

builder.Services.AddDbContextPool<PostgresContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("pgServer"))
);

//look into adding health checks here to see if the db is online?

builder.Services.AddMediation();
var app = builder.Build();
app.UseSwagger( opt =>
{
    opt.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
});
app.UseSwaggerUI();
app.MapControllers();
app.Run();