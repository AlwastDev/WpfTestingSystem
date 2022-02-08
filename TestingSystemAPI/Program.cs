using DataBaseLibrary;
using MethodsDataBaseLibrary;
using MethodsDataBaseLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TestingSystemDbContext>(options =>
{
    options.UseSqlServer(@"data source=DESKTOP-FP7F3LT\MSSQLSERVER_ALEX;initial catalog=TestingSystemDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        corsPolicyBuilder => { corsPolicyBuilder.AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddScoped<ICrudOperation, CrudOperation>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();