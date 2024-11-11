using MachineSystemDb;
using Microsoft.EntityFrameworkCore;

var context = new ApplicationDbContext();
var comRepo=new ComponentRepository(context);

var component = new Component {Name = "A", Description = "B", MachineId = 1};
var component2 = new Component {Name = "C", Description = "D", MachineId = 1};
var component3 = new Component {Name = "E", Description = "F", MachineId = 2};

comRepo.Add(component);
comRepo.Add(component2);
comRepo.Add(component3);

var machines = comRepo.GetAllComponents();
Console.WriteLine("Machines:");

foreach (var m in machines)
{
	Console.WriteLine($"ID: {m.Id}, Name: {m.Name}, Description: {m.Description}, MachineId: {m.MachineId}");
}

int machineId = 1; // Замініть на фактичний ID машини, яку хочете вивести
var machineWithComponents = context.Machines
	.Include(m => m.Components)
	.FirstOrDefault(m => m.Id == machineId);

if (machineWithComponents != null)
{
	Console.WriteLine($"Machine: {machineWithComponents.Name}, Type: {machineWithComponents.Type}");
	Console.WriteLine("Components:");

	foreach (var componento in machineWithComponents.Components)
	{
		Console.WriteLine($" - Component Name: {componento.Name}, Description: {componento.Description}");
	}
}
else
{
	Console.WriteLine("Machine not found.");
}
	