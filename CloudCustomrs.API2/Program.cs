using CloudCustomrs.API2.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

void ConfigurationServices(IServiceCollection services)
{
    services.AddHttpClient<Request>(client =>
    {
        client.BaseAddress = new Uri("https://localhost:7221"); // Set the base URL of the second API
    });
}