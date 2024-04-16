
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCap(x =>
{
    x.UseDashboard();
    x.UsePostgreSql("Host=localhost;Port=5432;Database=cap-server;Username=postgres;Password=Admin_123");
    x.UseRabbitMQ("localhost");
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
