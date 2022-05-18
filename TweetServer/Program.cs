using TweetServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using TweetServer.Repositories;
using RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add scopes to the build
builder.Services.AddScoped<ITweetRepo, TweetRepo>();
builder.Services.AddScoped<IMessageProducer, RabbitMQProducer>();
builder.Services.AddHostedService<RabbitMQConsumer>();

//Giving context access to mysql database
var connectionString = builder.Configuration.GetConnectionString(name: "MySqlConnection");
builder.Services.AddDbContext<ServerDbContext>(options => {
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

//Giving frontend access to this service
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});




var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();
