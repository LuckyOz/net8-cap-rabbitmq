var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCap(x =>
{
    x.UseDashboard();
    x.UsePostgreSql("Host=localhost;Port=5432;Database=cap-client;Username=postgres;Password=Admin_123");
    x.UseRabbitMQ(opt =>
    {
        opt.ConnectionFactoryOptions = options =>
        {
            options.HostName = "localhost";
            options.UserName = "rabbit";
            options.Password = "Admin_123";
        };
    });
});

builder.Services.AddControllers();

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
