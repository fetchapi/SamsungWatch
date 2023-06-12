using Microsoft.EntityFrameworkCore;
using SamsungWatch.Data;
using SamsungWatch.Data.EF;

var builder = WebApplication.CreateBuilder(args);
var mvcBuilder = builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("SamsungWatchDb");

builder.Services.AddDbContext<SamsungWatchDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<DbInitializer>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
using (var scope = app.Services.CreateScope())
{
  var serviceProvider = scope.ServiceProvider;
  try
  {
    var dbInitializer = serviceProvider.GetService<DbInitializer>();
    if (dbInitializer != null)
      dbInitializer.Seed()
                   .Wait();
  }
  catch (Exception ex)
  {
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while seeding the database.");
  }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
