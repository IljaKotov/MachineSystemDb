namespace MachineSystemDb;
using Npgsql;

public class TableInitializer
{
	private readonly string _connectionString;

	public TableInitializer(string connectionString)
	{
		_connectionString = connectionString;
	}

	public void Initialize()
	{
		using var connection = new NpgsqlConnection(_connectionString);
		connection.Open();

		var createMachineTable = @"
			CREATE TABLE IF NOT EXISTS Machines (
				Id SERIAL PRIMARY KEY,
				Name VARCHAR(100) NOT NULL,
    			Type VARCHAR(50) NOT NULL
    		)";

		using var machineCommand = new NpgsqlCommand(createMachineTable, connection);
		machineCommand.ExecuteNonQuery();
		Console.WriteLine("Table 'Machines' created or already exists.");

		var createComponentsTable = @"
			CREATE TABLE IF NOT EXISTS Components (
    			Id SERIAL PRIMARY KEY,
    			MachineId INT REFERENCES Machines(Id) ON DELETE CASCADE,
    			Name VARCHAR(100) NOT NULL,
    			Description TEXT
			)";
		
		using var componentsCommand = new NpgsqlCommand(createComponentsTable, connection);
		componentsCommand.ExecuteNonQuery();
		Console.WriteLine("Table 'Components' created or already exists.");
	}
}