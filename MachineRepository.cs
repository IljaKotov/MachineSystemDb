using Microsoft.EntityFrameworkCore;

namespace MachineSystemDb;

public class MachineRepository: IMachineRepository
{
	private readonly ApplicationDbContext _context;

	public MachineRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public void Add(Machine machine)
	{
		_context.Machines.Add(machine);
		_context.SaveChanges();
	}

	public Machine? GetById(int id)
	{
		return _context.Machines
			.Include(m=>m.Components)
			.FirstOrDefault(m => m.Id == id);
	}

	public List<Machine> GetAll()
	{
		return _context.Machines.Include(m => m.Components).ToList();
	}

	public void Update(Machine machine)
	{
		_context.Machines.Update(machine);
		_context.SaveChanges();
	}

	public void Delete(int id)
	{
		var machine = _context.Machines.Find(id);

		if (machine is null)
		{
			return;
		}

		_context.Machines.Remove(machine);
		_context.SaveChanges();
	}
}