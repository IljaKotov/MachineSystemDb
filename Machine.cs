namespace MachineSystemDb;

public class Machine
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Type { get; set; }

	public List<Component> Components { get; set; } = [];
}