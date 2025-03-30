var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(provider =>
{
	var config = provider.GetRequiredService<IConfiguration>();
	return new webapi.db.DbConnection(config.GetConnectionString("DefaultConnection") ?? "");
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.IncludeFields = true;
	options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
	options.JsonSerializerOptions.PropertyNamingPolicy = null;
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
