using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetNotes.Areas.Identity.Data;
using NetNotes.Repositories;
using NetNotes.Services;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("NetNotesContextConnection") ?? throw new InvalidOperationException("Connection string 'NetNotesContextConnection' not found.");

//builder.Services.AddDbContext<NetNotesContext>(options =>
    //options.UseSqlServer(connectionString));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NetNotesContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<NetNotesUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<NetNotesContext>();

builder.Services.AddTransient<NotesRepository>();
builder.Services.AddTransient<UserService>();
//builder.Services.AddTransient<CategorRepository>();
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
