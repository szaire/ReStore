using API.Contexts;
using API.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddDbContext<StoreContext>(options => 
		{
			options.UseSqlite(builder.Configuration.GetConnectionString("DevelopmentConnection"));
		});
		builder.Services.AddCors();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseCors(options => 
		{
			options.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
		});

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		var scope = app.Services.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
		var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

		try
		{
			context.Database.Migrate();
			DbInitializer.Init(context);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "A problem occurred during migration process.");
		}

		app.Run();
	}
}