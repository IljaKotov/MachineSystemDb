namespace MachineSystemDb;

public class Component
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	
	public int MachineId { get; set; }
	public Machine Machine { get; set; }
}