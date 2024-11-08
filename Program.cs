using MachineSystemDb;

using var testDb=new ApplicationDbContext();

Machine korch = new Machine
{
	Name = "Korch",
	Type = "Koryto"
};

testDb.Machines.Add(korch);
testDb.SaveChanges();
	
Console.WriteLine("Testing database was created successfully");

var machines = testDb.Machines.ToList();
Console.WriteLine("Machines:");

foreach (var machine in machines)
{
	Console.WriteLine($"Machine: {machine.Name},\t Type: {machine.Type}\n");
}