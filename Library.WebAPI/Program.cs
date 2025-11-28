using Library.IService;
using Library.Service;
using Library.Service.Services;
using Library.WebAPI.Uow;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSession();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibContext>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.Configure<MvcOptions>(opt =>
{
	opt.Filters.Add<AuthorizedFilter>();
});
builder.Services.AddCors(opt =>
{
	opt.AddDefaultPolicy(policy =>
	{
		policy.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});
var app = builder.Build();
app.UseCors();
app.UseSession();
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
