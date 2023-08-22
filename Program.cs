using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Learning Project",
    });
});

var configuration = builder.Configuration;


builder.Services.AddDbContext<SchoolAppContext>(options =>
{
   options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();


// Ensure the database is created and seeded during application startup
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<SchoolAppContext>();
//     context.Database.EnsureCreated();
// }



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    // Enable Swagger middleware
    app.UseSwagger();
    
    // Configure Swagger UI to open on the default route
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning Project v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
