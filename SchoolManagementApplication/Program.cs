using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NuGet.Protocol.Core.Types;
using SchoolManagementApplicationBAL;
using SchoolManagementApplicationDAL.Abstract;
using SchoolManagementApplicationDAL.Data;
using SchoolManagementApplicationDAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();
// Source - https://stackoverflow.com/a
// Posted by Kirk Larkin, modified by community. See post 'Timeline' for change history
// Retrieved 2025-11-29, License - CC BY-SA 4.0

//Injected the DBContext Class
builder.Services.AddDbContext<AuthDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolManagementAppAuthDbConnectionString")).ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)).EnableDetailedErrors());

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDBContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

/*Injected these services in the Program.cs file to use them in the controller class, Busienss Access Layer class and Repository class. This is done to implement the Dependency Injection in the application.*/
builder.Services.AddScoped<IEducator, EducatorRepo>();

builder.Services.AddScoped<IStudent, StudentRepo>();

builder.Services.AddScoped<ISuperAdmin, SuperAdminRepo>();

builder.Services.AddScoped<EducatorDetailsBAL>();

builder.Services.AddScoped<StudentDetailsBAL>();

builder.Services.AddScoped<SuperAdminBAL>();

/*Injected Class ends*/



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

//Add Code for Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
//app.MapRazorPages()
//   .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    //pattern: "{controller=Student}/{action=GetStudentDetails}/{id?}")
    .WithStaticAssets();

app.Run();
