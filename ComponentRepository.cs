using Microsoft.EntityFrameworkCore;

namespace MachineSystemDb;

public class ComponentRepository:IComponentRepository
{
	private readonly ApplicationDbContext _context;

	public ComponentRepository(ApplicationDbContext context)
	{
		_context = context;
	}
	
	public void Add(Component component)
	{
		_context.Components.Add(component);
		_context.SaveChanges();
	}

	public List<Component> GetAllComponents()
	{
		return _context.Components.ToList();
	}

	public Component? GetComponentById(int id)
	{
		return _context.Components.FirstOrDefault(c => c.Id == id);
	}

	public void Update(Component component)
	{
		_context.Components.Update(component);
		_context.SaveChanges();
	}

	public void Delete(Component component)
	{
		var componentToDelete = _context.Components.FirstOrDefault(c => c.Id == component.Id);

		if (componentToDelete is null)
		{
			return;
		}

		_context.Components.Remove(componentToDelete);
		_context.SaveChanges();
	}
}