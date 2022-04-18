using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PermissionBasedAuthorization.Data;
using PermissionBasedAuthorization.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString) ,ServiceLifetime.Transient);
//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


//using var scope = app.Services.CreateScope();

//var services = scope.ServiceProvider;
//var loggerFactory = services.GetRequiredService<ILoggerProvider>();
//var logger = loggerFactory.CreateLogger("app");

//try
//{
//    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//    await PermissionBasedAuthorization.Seeds.DefaultRoles.SeedAsync(roleManager);
//    await PermissionBasedAuthorization.Seeds.DefaultUsers.SeedBasicUserAsync(userManager);
//    await PermissionBasedAuthorization.Seeds.DefaultUsers.SeedSuperAdminUserAsync(userManager, roleManager);

//    logger.LogInformation("Data seeded");
//    logger.LogInformation("Application Started");
//}
//catch (System.Exception ex)
//{
//    logger.LogWarning(ex, "An error occurred while seeding data");
//}

app.Run();
