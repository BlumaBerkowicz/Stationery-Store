using Repository;
using Repositories;
using Repository;
using Services;
using Entities;
using ex02.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure the HTTP request pipeline.
builder.Services.AddDbContext<MyStoreDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("School")));


builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IRatingRepository, RatingRepository>();

builder.Services.AddScoped<IRatingService, RatingService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<MyStoreDBContext>();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseRatingMiddleware();
//app.UseErrorHandlingMiddleware();
app.MapControllers();

app.UseStaticFiles();

app.Run();
