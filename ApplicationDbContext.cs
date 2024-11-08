using Microsoft.EntityFrameworkCore;

namespace MachineSystemDb;

public sealed class ApplicationDbContext: DbContext
{
	public DbSet<Machine> Machines => Set<Machine>();
	public DbSet<Component> Components => Set<Component>();
	
	public ApplicationDbContext()=>Database.EnsureCreated();

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TestDB;Username=postgres;Password=27102023");
	}
}