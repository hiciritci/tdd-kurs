using eTicaret.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();


//migartion her proje aya�a kalt���ndan kendi olu�tutur.Canl�da istenen bir durum de�il. if blogu bu sebeple konuldu.
if (app.Environment.IsDevelopment())
{
    using (var scoped = app.Services.CreateScope())
    {
        var dbContex = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContex.Database.Migrate();
    }
}


app.Run();
