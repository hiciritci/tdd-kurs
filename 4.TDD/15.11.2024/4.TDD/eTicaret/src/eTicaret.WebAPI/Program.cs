using eTicaret.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();


//migartion her proje ayaða kaltýðýndan kendi oluþtutur.Canlýda istenen bir durum deðil. if blogu bu sebeple konuldu.
if (app.Environment.IsDevelopment())
{
    using (var scoped = app.Services.CreateScope())
    {
        var dbContex = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContex.Database.Migrate();
    }
}


app.Run();
