using Microsoft.EntityFrameworkCore;
using RegisteringApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionStrings");


// Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Register DbContext with the connection string
builder.Services.AddDbContext<RegistryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Register DbContext with the connection string
//builder.Services.AddDbContext<RegistryContext>(options =>
//   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseStaticFiles();  // Enable serving static files

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

