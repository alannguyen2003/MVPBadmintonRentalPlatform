using DataAccess;
using PlatformAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.AddCloudinarySetting(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddSeeding();
builder.Services.AddSwaggerAuthorization();
builder.Services.AddJwtAuthentication(builder.Configuration);
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

app.UseAuthorization();

app.UseCors(options =>
    options.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins("http://localhost:3000", "http://localhost:8081", "http://admin.smashit.com.vn",
                "https://smash-it-web.vercel.app"));

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<Seeding>();
    await context.MigrateDatabaseAsync();
    await context.SeedTransactionStatus();
    await context.SeedBookingStatus();
    await context.SeedSlotStatus();
    await context.SeedTransactionType();
    await context.SeedBanks();
    await context.SeedRole();
    await context.SeedAccount();
    await context.SeedBadmintonCourt();
    await context.SeedBadmintonCourtService();
    await context.SeedCourts();
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error while seeding data"); 
}
app.Run();