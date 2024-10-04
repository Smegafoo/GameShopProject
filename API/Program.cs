

using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolver;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Options;
using Autofac.Core;
using Business.Abstract;
using Business.Concrete.Managers;
using DataAccess.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MySqlContext>();

builder.Services.AddScoped(typeof(IGameService), typeof(GameManager));
builder.Services.AddScoped(typeof(IGameDal), typeof(EfGameDal));
builder.Services.AddScoped(typeof(IPlayerDal), typeof(EfPlayerDal));
builder.Services.AddScoped(typeof(IPlayerService), typeof(PlayerManager));
builder.Services.AddScoped(typeof(IGamereviewDal), typeof(EfGameReviewDal));
builder.Services.AddScoped(typeof(IGameReviewService), typeof(GameReviewManager));
builder.Services.AddScoped(typeof(IGameLibraryDal), typeof(EfGameLibraryDal));
builder.Services.AddScoped(typeof(IGameLibraryService), typeof(GameLibraryManager));
builder.Services.AddScoped(typeof(IAdminDal), typeof(EfAdminDal));
builder.Services.AddScoped(typeof(IAdminService), typeof(AdminManager));
builder.Services.AddScoped(typeof(ILibraryGameDal), typeof(EfLibraryGameDal));
builder.Services.AddScoped(typeof(ILibraryGameService), typeof(LibraryGameManager));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
