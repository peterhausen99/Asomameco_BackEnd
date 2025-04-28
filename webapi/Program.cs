using System.Text.Json;
using System.Text.Json.Serialization;
using webapi.db.connection;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins("http://localhost:3000")
												.AllowAnyHeader()
												.AllowAnyMethod();
					  });
});

builder.Services.AddScoped(provider =>
{
	var config = provider.GetRequiredService<IConfiguration>();
	var DbProvider = config.GetSection("DBSettings")["DbProvider"] ?? "";
	var connectionString = config.GetConnectionString("DefaultConnection") ?? "";
	IDbConnection db = DbProvider switch
	{
		_ when DbProvider == "MySql" => new MySqlDbConnection(connectionString),
		_ when DbProvider == "Postgresql" => new PostgreSqlDbConnection(connectionString),
		_ => throw new Exception($"{DbProvider} is not a valid connection type")
	};
	return db;
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.ConfigureHttpJsonOptions(o =>
{
	o.SerializerOptions.IncludeFields = true;
	o.SerializerOptions.PropertyNameCaseInsensitive = true;
	o.SerializerOptions.PropertyNamingPolicy = null;
	o.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
