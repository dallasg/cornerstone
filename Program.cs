using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using CornerstoneCRM.Auth;
using CornerstoneCRM.Data;
using CornerstoneCRM.Data.Repositories;
using CornerstoneCRM.Services;
using CornerstoneCRM.MultiTenancy;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Data/cornerstone.db"));

builder.Services.AddScoped<IConstituentRepository, EfConstituentRepository>();
builder.Services.AddScoped<ICaseRepository, EfCaseRepository>();
builder.Services.AddScoped<IInteractionRepository, EfInteractionRepository>();

builder.Services.AddScoped<IConstituentService, ConstituentService>();
builder.Services.AddScoped<ICaseService, CaseService>();
builder.Services.AddScoped<IInteractionService, InteractionService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenantProvider, TenantProvider>();
builder.Services.AddScoped<IUserContext, UserContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("FakeScheme") // Placeholder for MVP, real JWT later
    .AddScheme<AuthenticationSchemeOptions, FakeAuthHandler>("FakeScheme", null);

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
