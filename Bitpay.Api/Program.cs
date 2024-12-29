using Bitpay.Application;
using Bitpay.Application.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationServices();
builder.Services.AddDatabase(builder.Configuration["Database:ConnectionString"]!);

var app = builder.Build();

// // Configure the HTTP request pipeline
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializerAsync();

app.Run();