using Microsoft.EntityFrameworkCore;
using WordsTranslater.DAL;
using WordsTranslater.DAL.Repositories;
using WordsTranslater.Domain.Models;
using WordsTranslater.Service.Implementation;
using WordsTranslater.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
//builder.Services.AddScoped<IBaseRepository<Word,int>, WordRepository>();
builder.Services.AddScoped<IWordRepository, WordRepository>();
builder.Services.AddScoped<IWordService, WordService>();
builder.Services.AddScoped<ITranslateService, TranslateService>();



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

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Word}/{action=GetWords}/{id?}");

app.Run();
