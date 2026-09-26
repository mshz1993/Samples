using UserManagement_Web_API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=users.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowBlazor", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    opt.AddPolicy("MyAllowSpecificOrigins",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5300") 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowBlazor");
app.UseCors("MyAllowSpecificOrigins");

app.UseSwagger();
app.UseSwaggerUI();




app.MapControllers();
app.Run();