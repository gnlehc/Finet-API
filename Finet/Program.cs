using Finet.Context;
using Finet.Helpers;
using Finet.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<FinetContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("Finet")));

var AllowSpecificOrigins = "_AllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://10.0.2.2:5000");
                      });
});
builder.Services.AddScoped<MsUserHelper>();
builder.Services.AddScoped<MsUserService>();
builder.Services.AddScoped<MsCategoryHelper>();
builder.Services.AddScoped<MsCategoryService>();
builder.Services.AddScoped<MsAccountHelper>();
builder.Services.AddScoped<MsAccountService>();
builder.Services.AddScoped<TrExpenseHelper>();
builder.Services.AddScoped<TrExpenseService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
