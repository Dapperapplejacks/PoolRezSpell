using PoolRezWebApi.Executors;
using PoolRezWebApi.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Use method name as operationId
    c.CustomOperationIds(apiDesc =>
    {
        return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
    });
});

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ILoginExecutor, LoginExecutor>();
builder.Services.AddSingleton<IReservationExecutor, ReservationExecutor>();

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
app.Services.SaveSwaggerJson();

app.Run();
