using Microsoft.EntityFrameworkCore;
using metermngemen.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();

var app = builder.Build();

// ---- DB connection check (prints in terminal) ----
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
   try
{
    await db.Database.OpenConnectionAsync();
    Console.WriteLine(">>> DATABASE CONNECTED");
    await db.Database.CloseConnectionAsync();
}
catch (Exception ex)
{
    Console.WriteLine(">>> DATABASE ERROR: " + ex.Message);
    if (ex.InnerException != null)
        Console.WriteLine(">>> INNER: " + ex.InnerException.Message);
}
}
// --------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();