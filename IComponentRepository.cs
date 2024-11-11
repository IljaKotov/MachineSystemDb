namespace MachineSystemDb;

public interface IComponentRepository
{
	void Add(Component component);
	List<Component> GetAllComponents();
	Component? GetComponentById(int id);
	void Update(Component component);
	void Delete(Component component);
}
	