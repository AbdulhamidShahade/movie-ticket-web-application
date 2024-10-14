using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Web.Data;
using MovieTicket.Web.Models;
using MovieTicket.Web.Repositories.IRepository;
using MovieTicket.Web.Repositories.Queries.ADONet.ActorQueries;
using MovieTicket.Web.Repositories.Queries.ADONet.CategoryQueries;
using MovieTicket.Web.Repositories.Queries.ADONet.MovieQueries;
using MovieTicket.Web.Repositories.Queries.ADONet.ProducerQueries;
using MovieTicket.Web.Repositories.Repository;
using MovieTicketWebApplication.Repositories.Queries.ADONet.ActorQueries;
using MovieTicketWebApplication.Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLServer"));
//});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MySQL"), new MySqlServerVersion(new Version(10, 4, 30)),mysqlOptions =>
        {
            mysqlOptions.EnableRetryOnFailure();
        });
});

builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<ShoppingCart>();

builder.Services.AddScoped<ActorMoviesDataProvider>();
builder.Services.AddScoped<CategoryMoviesDataProvider>();
builder.Services.AddScoped<CinemaMoviesDataProvider>();
builder.Services.AddScoped<ProducerMoviesDataProvider>();
builder.Services.AddScoped<MovieActorsDataProvider>();
builder.Services.AddScoped<MovieCategoriesDataProvider>();
builder.Services.AddScoped<MovieProducersDataProvider>();
builder.Services.AddScoped<CountryActorsDataProvider>();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
