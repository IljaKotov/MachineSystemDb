namespace MachineSystemDb;
using Npgsql;

public class DatabaseInitializer
{
	private readonly string _connectionString;
	private readonly string _databaseName;

	public DatabaseInitializer(string connectionString,string databaseName)
	{
		_connectionString=connectionString;
		_databaseName=databaseName;
	}

	public void Initialize()
	{
		using var connection = new NpgsqlConnection(_connectionString);
		connection.Open();
		
		var checkDb=$"SELECT 1 FROM pg_database WHERE datname = '{_databaseName}'";
		using var checkCommand = new NpgsqlCommand(checkDb, connection);
		var exists = checkCommand.ExecuteScalar() != null;

		if (exists is false)
		{
			var creatDb = $"CREATE DATABASE {_databaseName}";
			using var createCommand = new NpgsqlCommand(creatDb, connection);
			createCommand.ExecuteNonQuery();
			Console.WriteLine("Database created");
		}
		else
		{
			Console.WriteLine("Database already exists");
		}
	}
}