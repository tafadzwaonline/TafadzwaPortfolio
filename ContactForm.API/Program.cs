using ContactForm.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Personal Setup / Portfolio
//Connection
builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("http://mysystem.ddns.net/tafadzwakahwai", "https://mysystem.ddns.net/tafadzwakahwai") // Replace with your Blazor app URLs
              .AllowAnyMethod()
              .WithHeaders(HeaderNames.ContentType);
    });
});

//link the projects together: client, api
//app.UseCors(policy =>
//{
//    policy.WithOrigins("http://localhost:7005", "https://localhost:7005") //do not add the forward slash at end
//    .AllowAnyMethod()
//    .WithHeaders(HeaderNames.ContentType);
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

   
}

//app.UseSwagger();
//app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
