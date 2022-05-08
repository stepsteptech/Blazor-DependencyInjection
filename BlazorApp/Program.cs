using BlazorApp.Data;
using DataAccessLayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Step 1
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite(@"Data Source=DataBase\DiDemo.db"));
//step 2
builder.Services.AddScoped<ApplicationDbContext>(serviceprovider =>
serviceprovider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

//inject Service
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
