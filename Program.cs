using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using TH.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PhotoContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("PCMSAppCon")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Json Serializer
builder.Services.AddControllers().AddNewtonsoftJson(option =>
option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();


app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

