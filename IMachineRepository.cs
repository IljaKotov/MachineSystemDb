namespace MachineSystemDb;

public interface IMachineRepository
{
	void Add(Machine machine);
	Machine? GetById(int id);
	List<Machine> GetAll();
	void Update(Machine machine);
	void Delete(int id);
}